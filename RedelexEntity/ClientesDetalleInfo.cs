using System;
using System.Collections.Generic;
using System.Data.Objects;
using System.Globalization;
using System.Linq;
using System.Web;

namespace RedelexAdmin.Models
{
    
    public class ClientesDetalleInfo
    {
        public string CuentaId { get; set; }
        public Licencia Licencia { get; set; }
        public string NombreCuenta { get; set; }
        public int TotalProcesos { get; set; }
        public int TotalProcesosActivos { get; set; }
        public int TotalProcesosInactivos { get; set; }
        public int TotalProcesosEliminados { get; set; }
        public int TotalProcesosConVJConnect { get; set; }
        public decimal MaximoProcesos { get; set; }
        public int MaximoViculosVJConnect { get; set; }
        public decimal MaximoEspacioDisco { get; set; }
        public int MaximoUsuarios { get; set; }
        public string RepositorioDocumentos { get; set; }


        private DateTime? _fechaVencimiento;
        public DateTime? FechaVencimiento
        {
          get { return _fechaVencimiento; }
          set { _fechaVencimiento = value;}
        }

        public string FechaVencimientoString
        {
            get
            {
                if (_fechaVencimiento.HasValue)
                    return _fechaVencimiento.Value.ToString("yyyy-MM-dd");
                return "--Sin Vencimiento--";
            }
          
        }

        public List<AuditoriaUsuario> AuditoriaUsuarios { get; set; }

        public ClientesDetalleInfo()
        {
        }

        public ClientesDetalleInfo(string CuentaId)
        {
            GetDetalleInfo(CuentaId);
        }

        private void GetDetalleInfo(string CuentaId)
        {
            this.TotalProcesos = this.TotalProcesosActivos = this.TotalProcesosInactivos = this.TotalProcesosEliminados = 0;
            this.Licencia = new Licencia();
            this.AuditoriaUsuarios = new List<AuditoriaUsuario>();

            using (var context = new RedelexEntities()) 
            {
                string _sql="";
                    
                try
                {
                    var _query = (from b in context.auditoria_usuarios
                               where b.codigo_cliente.Equals(CuentaId)
                               select new AuditoriaUsuario { RegistroId = b.item, FechaHora = b.fecha_hora, Obligacion=b.obligacion, UsuarioId=b.codugo_usuario, DireccionIp = b.ip, Accion = b.codigo_accion}).OrderByDescending(a=>a.FechaHora).Take(50);

                    var _q2 = (from a in context.clientes
                                   where a.codigo.Equals(CuentaId)
                                  select new ClientesDetalleInfo { CuentaId = a.codigo, FechaVencimiento = a.fecha_expiracion, NombreCuenta = a.nombre, MaximoProcesos = a.maximo_procesos, MaximoUsuarios = a.maximo_usuarios, MaximoViculosVJConnect = a.VJConnectMaximoProcesos, MaximoEspacioDisco = a.maximo_espacio_disco, RepositorioDocumentos = a.RepositorioDocumentos }).FirstOrDefault();


                    this.AuditoriaUsuarios = _query.ToList();

                    this.FechaVencimiento = _q2.FechaVencimiento;
                    this.NombreCuenta = _q2.NombreCuenta;
                    this.MaximoProcesos = _q2.MaximoProcesos;
                    this.MaximoUsuarios = _q2.MaximoUsuarios;
                    this.MaximoViculosVJConnect = _q2.MaximoViculosVJConnect;
                    this.RepositorioDocumentos = _q2.RepositorioDocumentos;
                }
                catch (Exception e)
                {
                    
                    throw new NotImplementedException(_sql,e.InnerException);
                }
            }

            using (var context = new RedelexEntities())
            {
                try
                {
                    
                    var _query = (from b in context.clientes
                                  where b.codigo.Equals(CuentaId)
                                  select b).FirstOrDefault();
                    
                    this.Licencia.MaximoEspacioDisco = _query.maximo_espacio_disco;
                    this.Licencia.MaximoProcesos = _query.maximo_procesos;
                    this.Licencia.VJConnectMaximoProcesos = _query.VJConnectMaximoProcesos;
                    this.Licencia.TipoLicenciaId = _query.TipoLicenciaId;
                    this.Licencia.TipoLicenciaNombre = _query.TipoLicencias.TipoLicencia;

                }
                catch (Exception e)
                {
                    throw new NotSupportedException("", e.InnerException);
                }

                try
                {
                    
                    
                    var _query = (from b in context.procesos
                                  where b.codigo_cliente.Equals(CuentaId)
                                  select b.obligacion).Count();

                    if (_query != 0)
                        this.TotalProcesos = _query;

                    var _query2 = (from b in context.procesos
                                   join r in context.tipo_estados on b.tipo_estado equals r.tipo_estado
                              where b.codigo_cliente.Equals(CuentaId) && r.proceso_vigente.Equals("S") && b.eliminado == false
                              select b.obligacion).Count();
                    if (_query2 != 0)

                        this.TotalProcesosActivos = _query2;


                    var _query3 = (from b in context.procesos
                                   join r in context.tipo_estados on b.tipo_estado equals r.tipo_estado
                                   where b.codigo_cliente.Equals(CuentaId) && r.proceso_vigente.Equals("N") && b.eliminado == false
                              select b.obligacion).Count();

                    if (_query3 != 0)
                        this.TotalProcesosInactivos = _query3;

                    var _query4 = (from b in context.procesos
                              where b.codigo_cliente.Equals(CuentaId) && b.eliminado == true
                              select b.obligacion).Count();

                    if (_query4 != 0)
                        this.TotalProcesosEliminados = _query4;

                    var _query5 = (from b in context.ProcesosDS
                                   where b.Eliminado == false && b.procesos.codigo_cliente.Equals(CuentaId) && b.procesos.eliminado == false && b.procesos.tipo_estados.proceso_vigente.Equals("S")
                                   select b.IdProceso).Count();

                    if (_query5 != 0)
                        this.TotalProcesosConVJConnect = _query5;

                }
                catch (Exception e)
                {
                    throw new NotImplementedException("",e.InnerException);
                }
            }

        }

        public List<ClientesDetalleInfo> GetClientesPorLicencia(int? LicenciaId)
        {
            using (RedelexEntities context = new RedelexEntities())
            {
                var _query = (from a in context.clientes
                              where a.TipoLicenciaId == LicenciaId && a.activo == true
                              select new ClientesDetalleInfo { CuentaId = a.codigo, FechaVencimiento = a.fecha_expiracion, NombreCuenta = a.nombre, MaximoProcesos = a.maximo_procesos, MaximoUsuarios = a.maximo_usuarios, MaximoViculosVJConnect = a.VJConnectMaximoProcesos, MaximoEspacioDisco = a.maximo_espacio_disco });

                return (_query.ToList());
            }

        }

        public List<EstadisticasFecha> GetMovimientosVJConnect(string CuentaId, int Dias)
        {
            DateTime _hoy = DateTime.UtcNow;
            DateTime _desde = _hoy.AddDays(-Dias);
            
            using (RedelexEntities context = new RedelexEntities())
            {
                //var _queryResult = (from act in context.ActuacionesDS 
                //                    join pds in context.ProcesosDS on act.IdProceso equals pds.IdProceso
                                    
                //                    join p in context.procesos on pds.obligacion equals p.obligacion
                //                    where p.codigo_cliente.Equals(CuentaId) && act.FechaInsercion >= _desde && act.FechaInsercion <= _hoy

                //                    group act by EntityFunctions.TruncateTime(act.FechaInsercion) into g
                                    
                //                    select new EstadisticasFecha { Fecha = g.Key.Value, Total = g.Count() });

                var _queryResult = (from act in context.ActuacionesDS                  
                                    where act.ProcesosDS.procesos.codigo_cliente.Equals(CuentaId) && act.FechaInsercion >= _desde && act.FechaInsercion <= _hoy
                                    group act by EntityFunctions.TruncateTime(act.FechaInsercion) into g
                                    select new EstadisticasFecha { Fecha = g.Key.Value, Total = g.Count() }).OrderByDescending(a =>a.Fecha).ToList();
                return _queryResult;
            }
        }

    }
    public class AuditoriaUsuario
    {
        public decimal RegistroId { get; set; }
        public string Accion { get; set; }
        public decimal Obligacion { get; set; }
        public DateTime FechaHora { get; set; }
        public string FechaHoraString
        {
            get
            {
                return this.FechaHora.ToString("yyyy-MM-dd hh:mm:ss tt");
            }
        }
        public string UsuarioId { get; set; }
        public string CuentaId { get; set; }
        public string UsuarioNombre { get; set; }
        public string DireccionIp { get; set; }

    }

    public class Licencia
    {
        public decimal MaximoProcesos { get; set; }
        public int VJConnectMaximoProcesos { get; set; }
        public decimal MaximoEspacioDisco { get; set; }
        public DateTime FechaExpiracion { get; set; }
        public string FechaExpiracionString
        {
            get
            {
                return this.FechaExpiracion.ToString("yyyy-MM-dd hh:mm:ss");
            }
        }
        public int TipoLicenciaId { get; set; }
        public string TipoLicenciaNombre { get; set; }

        public Licencia()
        {
            MaximoEspacioDisco = 0;
            VJConnectMaximoProcesos = 0;
            MaximoEspacioDisco = 0;
            FechaExpiracion = DateTime.MinValue;
            TipoLicenciaId = 0;
            TipoLicenciaNombre = "";
        }
    }

    public class EstadisticasFecha
    {
        private DateTime _fecha;
        public DateTime Fecha
        {
            get { return _fecha; }
            set { _fecha = value; }
        }

        public string FechaString
        {
            get { return _fecha.ToString("yyyy-MM-dd"); }
        }
        public string FechaDiaSemanaString
        {
            get
            {
                return _fecha.ToString("dddd",new CultureInfo("es-ES"));
            }
        }

        private int _total;
        public int Total
        {
            get { return _total; }
            set { _total = value; }
        }

        public string CuentaId;

        public string CuentaNombre { get; set; }

    }
    public class EstadisticasRangoFechas
    {
        public const string TotalProcesosNuevos = "TotalProcesosNuevos";
        public const string TotalActuacionesNuevas = "TotalActuacionesNuevas";
        public const string TotalUsuariosActivos = "TotalUsuariosActivos";
        public const string TotalProcesosConsultados = "TotalProcesosConsultados";
        public const string TotalProcesosConsultadosCuenta = "TotalProcesosConsultadosCuenta";
        public const string TotalProcesosCreadosCuenta = "TotalProcesosCreadosCuenta";

        public string ClaseEstadistica { get; set; }

        public List <EstadisticasFecha> Estadisticas { get; set; }
        private RedelexEntities context = new RedelexEntities();

        private DateTime _fechaInicial;
        public DateTime FechaInicial
        {
          get { return _fechaInicial; }
        }

        private DateTime _fechaFinal;
        public DateTime FechaFinal
        {
          get { return _fechaFinal; }
        }

        /// <summary>
        /// Estadisticas en un rango de fechas especifico
        /// </summary>
        /// <param name="FechaInicial"></param>
        /// <param name="FechaFinal"></param>
        /// <param name="ClaseEstadistica"></param>
        public EstadisticasRangoFechas(DateTime FechaInicial, DateTime FechaFinal, string ClaseEstadistica)
        {
            this._fechaInicial = FechaInicial;
            this._fechaFinal = FechaFinal;

            bool ret = GetEstadisticas(ClaseEstadistica);

        }
        /// <summary>
        /// Estadísitcas en los días pasados
        /// </summary>
        /// <param name="NumeroDias"></param>
        public EstadisticasRangoFechas(int NumeroDias, string ClaseEstadistica)
        {
            this.ClaseEstadistica = ClaseEstadistica;
            this._fechaFinal = DateTime.Now;
            this._fechaInicial = _fechaFinal.AddDays(NumeroDias * -1);

            bool ret = GetEstadisticas(ClaseEstadistica);

        }

        private bool GetEstadisticas(string ClaseEstadistica)
        {

            List<EstadisticasFecha> _queryResult = new List<EstadisticasFecha>();
            
            if (ClaseEstadistica == TotalProcesosNuevos)
            {
                _queryResult = (from a in context.procesos
                              where a.fecha_digitacion >= _fechaInicial && a.fecha_digitacion <= EntityFunctions.AddDays(_fechaFinal,1)
                              group a by EntityFunctions.TruncateTime(a.fecha_digitacion) into g
                               select new EstadisticasFecha { Fecha = g.Key.Value, Total = g.Count() }).ToList();
            }

            if (ClaseEstadistica == TotalActuacionesNuevas)
            {
                _queryResult = (from a in context.actuaciones_judiciales
                          where a.fecha_insercion >= _fechaInicial && a.fecha_insercion <= EntityFunctions.AddDays(_fechaFinal,1)
                          group a by EntityFunctions.TruncateTime(a.fecha_insercion) into g
                               select new EstadisticasFecha { Fecha = g.Key.Value, Total = g.Count() }).ToList();
            }
            if (ClaseEstadistica == TotalUsuariosActivos)
            {
                _queryResult = (from a in context.auditoria_usuarios
                                where a.codigo_accion == "logon" && a.fecha_hora >= _fechaInicial && a.fecha_hora <= EntityFunctions.AddDays(_fechaFinal, 1)
                                group a by EntityFunctions.TruncateTime(a.fecha_hora) into g
                                select new EstadisticasFecha { Fecha = g.Key.Value, Total = g.Count() }).ToList();
            }

            if (ClaseEstadistica == TotalProcesosConsultados)
            {
                _queryResult = (from a in context.auditoria_usuarios
                                where a.codigo_accion == "conpro" && a.fecha_hora >= _fechaInicial && a.fecha_hora <= EntityFunctions.AddDays(_fechaFinal, 1)
                                group a by EntityFunctions.TruncateTime(a.fecha_hora) into g
                                select new EstadisticasFecha { Fecha = g.Key.Value, Total = g.Count() }).ToList();
            }

            if (ClaseEstadistica == TotalProcesosCreadosCuenta)
            {
                _queryResult = (from a in context.procesos
                                join c in context.clientes on a.codigo_cliente equals c.codigo
                                where a.fecha_digitacion >= _fechaInicial && a.fecha_digitacion <= EntityFunctions.AddDays(_fechaFinal, 1)
                                group a by new { a.codigo_cliente, c.nombre } into g
                                select new EstadisticasFecha { CuentaId = g.Key.codigo_cliente, CuentaNombre=g.Key.nombre , Total = g.Count() }).ToList();
            }

            if (ClaseEstadistica == TotalProcesosConsultadosCuenta)
            {
                _queryResult = (from a in context.auditoria_usuarios
                                join c in context.clientes on a.codigo_cliente equals c.codigo
                                where a.fecha_hora >= _fechaInicial && a.fecha_hora <= EntityFunctions.AddDays(_fechaFinal, 1)
                                group a by new { a.codigo_cliente, c.nombre } into g
                                select new EstadisticasFecha { CuentaId = g.Key.codigo_cliente, CuentaNombre = g.Key.nombre, Total = g.Count() }).ToList();
            }
            
            this.Estadisticas = _queryResult;

            return true;
        }

    }
    

    
}