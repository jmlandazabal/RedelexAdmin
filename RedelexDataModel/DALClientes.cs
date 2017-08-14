using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RedelexDTO;

namespace RedelexDataModel
{
    public static partial class DALClientes
    {
        public static List<RedelexDTO.AuditoriaUsuario> GetAuditoriaUsuarios(string cuentaId)
        {
            using (RedelexEntities context = new RedelexEntities())
            {
                try
                {
                    var _query = (from b in context.auditoria_usuarios
                                  where b.codigo_cliente.Equals(cuentaId)
                                  select new RedelexDTO.AuditoriaUsuario { RegistroId = b.item, FechaHora = b.fecha_hora, Obligacion = b.obligacion, UsuarioId = b.codugo_usuario, DireccionIp = b.ip, Accion = b.codigo_accion }).OrderByDescending(a => a.FechaHora).Take(50);
                    return _query.ToList();
                }
                catch (Exception e)
                {
                    return new List<AuditoriaUsuario>();
                }
            }

        }

        public static RedelexDTO.ClienteDetalleInfo GetInfoCuenta(string cuentaId)
        {
            using (RedelexEntities context = new RedelexEntities())
            {
                try
                {
                    var _q = (from a in context.clientes
                              where a.codigo.Equals(cuentaId)
                              select new { CuentaId = a.codigo, FechaVencimiento = a.fecha_expiracion, NombreCuenta = a.nombre, MaximoProcesos = a.maximo_procesos, MaximoUsuarios = a.maximo_usuarios, MaximoViculosVJConnect = a.VJConnectMaximoProcesos, MaximoEspacioDisco = a.maximo_espacio_disco, RepositorioDocumentos = a.RepositorioDocumentos, TipoLicenciaId = a.TipoLicenciaId, TipoLicenciaNombre = a.TipoLicencias.TipoLicencia, Activo = a.activo, LicenseKey = a.license_key }).FirstOrDefault();

                    ClienteDetalleInfo _r = new ClienteDetalleInfo();
                    _r.CuentaId = _q.CuentaId;
                    _r.NombreCuenta = _q.NombreCuenta;
                    _r.RepositorioDocumentos = _q.RepositorioDocumentos;
                    _r.Activo = _q.Activo;
                    _r.LicenciaInfo.LicenseKey = _q.LicenseKey;
                    _r.LicenciaInfo.MaximoProcesos = _q.MaximoProcesos;
                    _r.LicenciaInfo.MaximoEspacioDisco = _q.MaximoEspacioDisco;
                    _r.LicenciaInfo.MaximoUsuarios = _q.MaximoUsuarios;
                    _r.LicenciaInfo.VJConnectMaximoProcesos = _q.MaximoViculosVJConnect;
                    _r.LicenciaInfo.TipoLicenciaId = _q.TipoLicenciaId;
                    _r.LicenciaInfo.TipoLicenciaNombre = _q.TipoLicenciaNombre;
                    _r.LicenciaInfo.FechaExpiracion = _q.FechaVencimiento.Value;

                    return _r;
                }
                catch (Exception e)
                {
                    return new ClienteDetalleInfo();
                }
            }

        }

        public static List<RedelexDTO.HTTP500Errors> GetHTTP500Errors(string cuentaId)
        {
            using (RedelexEntities context = new RedelexEntities())
            {
                var _query = (from b in context.HTTP500Errors
                              join c in context.usuarios on b.id_usuario equals c.id_usuario
                              join d in context.clientes on b.id_cuenta equals d.codigo
                              where b.id_cuenta.Equals(cuentaId) && b.Dt >= DbFunctions.AddDays(DateTime.Now, -30)
                              select new RedelexDTO.HTTP500Errors
                              {
                                  AspColumn = b.AspColumn,
                                  AspDesc = b.AspDesc,
                                  Data = b.Data,
                                  AspLine = b.AspLine,
                                  AspNumber = b.AspNumber,
                                  FechaHora = b.Dt,
                                  ErrDesc = b.ErrDesc,
                                  ErrNumber = b.ErrNumber,
                                  Id = b.Id,
                                  CuentaId = b.id_cuenta,
                                  UsuarioId = b.id_usuario,
                                  Ip = b.Ip,
                                  Method = b.Method,
                                  Ref = b.Ref,
                                  Ua = b.Ua,
                                  Url = b.Url,
                                  CuentaNombre = d.nombre,
                                  UsuarioNombre = c.nombre
                              }).OrderByDescending(a => a.FechaHora).ToList();

                return _query;
            }
        }

        public static List<RedelexDTO.HTTP500Errors> GetHTTP500Errors(string cuentaId, DateTime FechaIni, DateTime FechaFin)
        {
            using (RedelexEntities context = new RedelexEntities())
            {
                var _query = (from b in context.HTTP500Errors
                              join c in context.usuarios on b.id_usuario equals c.id_usuario
                              join d in context.clientes on b.id_cuenta equals d.codigo
                              where b.id_cuenta.Equals(cuentaId) && b.Dt >= FechaIni && b.Dt<= FechaFin
                              select new RedelexDTO.HTTP500Errors
                              {
                                  AspColumn = b.AspColumn,
                                  AspDesc = b.AspDesc,
                                  Data = b.Data,
                                  AspLine = b.AspLine,
                                  AspNumber = b.AspNumber,
                                  FechaHora = b.Dt,
                                  ErrDesc = b.ErrDesc,
                                  ErrNumber = b.ErrNumber,
                                  Id = b.Id,
                                  CuentaId = b.id_cuenta,
                                  UsuarioId = b.id_usuario,
                                  Ip = b.Ip,
                                  Method = b.Method,
                                  Ref = b.Ref,
                                  Ua = b.Ua,
                                  Url = b.Url,
                                  CuentaNombre = d.nombre,
                                  UsuarioNombre = c.nombre
                              }).OrderByDescending(a => a.FechaHora).ToList();

                return _query;
            }
        }

        public static int GetTotalProcesosConVJConnects(string cuentaId)
        {
            using (RedelexEntities context = new RedelexEntities())
            {
                var _query = (from b in context.ProcesosDS
                              where b.Eliminado == false && b.procesos.codigo_cliente.Equals(cuentaId) && b.procesos.eliminado == false && b.procesos.tipo_estados.proceso_vigente.Equals("S")
                              select b.IdProceso).Count();

                return _query;
            }
            
        }

        public static int GetTotalProcesosInactivos(string cuentaId)
        {
            using (RedelexEntities context = new RedelexEntities())
            {
                var _query = (from b in context.procesos
                              join r in context.tipo_estados on b.tipo_estado equals r.tipo_estado
                              where b.codigo_cliente.Equals(cuentaId) && r.proceso_vigente.Equals("N") && b.eliminado == false
                              select b.obligacion).Count();


                return _query;
            }
        }

        public static int GetTotalProcesosActivos(string cuentaId)
        {
            using (RedelexEntities context = new RedelexEntities())
            {
                var _query = (from b in context.procesos
                              join r in context.tipo_estados on b.tipo_estado equals r.tipo_estado
                              where b.codigo_cliente.Equals(cuentaId) && r.proceso_vigente.Equals("S") && b.eliminado == false
                              select b.obligacion).Count();


                return _query;
            }

        }

        public static int GetTotalProcesos(string cuentaId)
        {
            using (RedelexEntities context = new RedelexEntities())
            {
                var _query = (from b in context.procesos
                              where b.codigo_cliente.Equals(cuentaId)
                              select b.obligacion).Count();

                
                    return _query;
            }
        }

        public static RedelexDTO.EstadisticasFecha GetTotalProcesosNuevos(DateTime FechaInicial, DateTime FechaFinal)
        {
            using (RedelexEntities context = new RedelexEntities())
            {
                var _query = (from a in context.procesos
                              where a.fecha_digitacion >= FechaInicial && a.fecha_digitacion <= DbFunctions.AddDays(FechaFinal, 1)
                              group a by DbFunctions.TruncateTime(a.fecha_digitacion) into g
                              select new RedelexDTO.EstadisticasFecha { Fecha = g.Key.Value, Total = g.Count() });

                return _query.FirstOrDefault();
            }
        }

        public static RedelexDTO.Estadisticas GetMovimientosVJConnect(string CuentaId, int Dias)
        {
            RedelexDTO.Estadisticas _e = new RedelexDTO.Estadisticas(Dias);

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
                                    group act by DbFunctions.TruncateTime(act.FechaInsercion) into g
                                    select new EstadisticasFecha { Fecha = g.Key.Value, Total = g.Count() }).OrderByDescending(a => a.Fecha).ToList();

                _e.Estadistica = _queryResult;
                return _e;
            }
        }

        public static List<ClienteDetalleInfo> GetClientesPorLicencia(int? LicenciaId)
        {
            using (RedelexEntities context = new RedelexEntities())
            {
                var _query = (from a in context.clientes
                              where a.TipoLicenciaId == LicenciaId && a.activo == true
                              select new ClienteDetalleInfo { CuentaId = a.codigo, NombreCuenta = a.nombre, LicenciaInfo = new Licencia { FechaExpiracion = a.fecha_expiracion.Value, MaximoProcesos = a.maximo_procesos, MaximoUsuarios = a.maximo_usuarios, VJConnectMaximoProcesos = a.VJConnectMaximoProcesos, MaximoEspacioDisco = a.maximo_espacio_disco } });

                return (_query.ToList());
            }

        }

        public static int UpdateInfoBasica(RedelexDTO.ClienteDetalleInfo Cliente)
        {
            using (RedelexEntities _db = new RedelexEntities())
            {
                var update = (from a in _db.clientes
                              where a.codigo.Equals(Cliente.CuentaId)
                              select a).FirstOrDefault();
                if (update != null)
                {

                    update.fecha_expiracion = Cliente.FechaExpiracion;
                    update.maximo_usuarios = Cliente.LicenciaInfo.MaximoUsuarios;
                    update.VJConnectMaximoProcesos = Cliente.LicenciaInfo.VJConnectMaximoProcesos;
                    update.maximo_espacio_disco = Cliente.LicenciaInfo.MaximoEspacioDisco;
                    update.maximo_procesos = Cliente.LicenciaInfo.MaximoProcesos;
                    update.RepositorioDocumentos = Cliente.RepositorioDocumentos;
                    update.activo = Cliente.Activo;

                    try
                    {
                        _db.SaveChanges();
                    }
                    catch (Exception e)
                    {
                        return -1;
                    }
                    return 1;

                }
            }
            return 0;


            //using (var context = new RedelexEntities())
            //{

            //    try
            //    {
            //        //context.Entry(Cliente).State = EntityState.Modified;
            //        //context.SaveChanges();
            //        var entity = context.clientes.Find(Cliente.CuentaId);
            //        context.Entry(entity).CurrentValues.SetValues(Cliente);
            //        context.Entry(Cliente).State = EntityState.Modified;
            //        context.SaveChanges();
            //        context.Entry(Cliente).State = EntityState.Unchanged;
            //    }
            //    catch (Exception e)
            //    {

            //        return -1;
            //    }
            //    return 1;
            //}

        }

    }
}
