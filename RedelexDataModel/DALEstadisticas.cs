using System;
using System.Collections.Generic;
using System.Data.Entity.Core;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace RedelexDataModel
{

    public static class DALEstadisticas
    {
        

        /// <summary>
        /// Estadísitcas en los días pasados
        /// </summary>
        /// <param name="NumeroDias"></param>
        public static List<RedelexDTO.EstadisticasFecha> GetEstadisticas(int NumeroDias, string ClaseEstadistica)
        {
            RedelexEntities context = new RedelexEntities();

            DateTime _fechaFinal = DateTime.Now;
            DateTime _fechaInicial = DateTime.Now.AddDays(NumeroDias * -1);
            var ret = _getEstadisticas(ClaseEstadistica, _fechaInicial, _fechaFinal);

            return ret;

        }

        private static List<RedelexDTO.EstadisticasFecha> _getEstadisticas(string ClaseEstadistica, DateTime FechaInicial, DateTime FechaFinal )
        {
            RedelexEntities context = new RedelexEntities();
            List<RedelexDTO.EstadisticasFecha> _queryResult = new List<RedelexDTO.EstadisticasFecha>();


            if (ClaseEstadistica == RedelexDTO.TipoEstadistica.TotalProcesosNuevos)
            {
                _queryResult = (from a in context.procesos
                                where a.fecha_digitacion >= FechaInicial && a.fecha_digitacion <= DbFunctions.AddDays(FechaFinal, 1)
                                group a by DbFunctions.TruncateTime(a.fecha_digitacion) into g
                                select new RedelexDTO.EstadisticasFecha { Fecha = g.Key.Value, Total = g.Count() }).ToList();
            }

            if (ClaseEstadistica == RedelexDTO.TipoEstadistica.TotalActuacionesNuevas)
            {
                _queryResult = (from a in context.actuaciones_judiciales
                                where a.fecha_insercion >= FechaInicial && a.fecha_insercion <= DbFunctions.AddDays(FechaFinal, 1)
                                group a by DbFunctions.TruncateTime(a.fecha_insercion) into g
                                select new RedelexDTO.EstadisticasFecha { Fecha = g.Key.Value, Total = g.Count() }).ToList();
            }
            if (ClaseEstadistica == RedelexDTO.TipoEstadistica.TotalUsuariosActivos)
            {
                _queryResult = (from a in context.auditoria_usuarios
                                where a.codigo_accion == "logon" && a.fecha_hora >= FechaInicial && a.fecha_hora <= DbFunctions.AddDays(FechaFinal, 1)
                                group a by DbFunctions.TruncateTime(a.fecha_hora) into g
                                select new RedelexDTO.EstadisticasFecha { Fecha = g.Key.Value, Total = g.Count() }).ToList();
            }

            if (ClaseEstadistica == RedelexDTO.TipoEstadistica.TotalProcesosConsultados)
            {
                _queryResult = (from a in context.auditoria_usuarios
                                where a.codigo_accion == "conpro" && a.fecha_hora >= FechaInicial && a.fecha_hora <= DbFunctions.AddDays(FechaFinal, 1)
                                group a by DbFunctions.TruncateTime(a.fecha_hora) into g
                                select new RedelexDTO.EstadisticasFecha { Fecha = g.Key.Value, Total = g.Count() }).ToList();
            }

            if (ClaseEstadistica == RedelexDTO.TipoEstadistica.TotalProcesosCreadosCuenta)
            {
                _queryResult = (from a in context.procesos
                                join c in context.clientes on a.codigo_cliente equals c.codigo
                                where a.fecha_digitacion >= FechaInicial && a.fecha_digitacion <= DbFunctions.AddDays(FechaFinal, 1)
                                group a by new { a.codigo_cliente, c.nombre } into g
                                select new RedelexDTO.EstadisticasFecha { CuentaId = g.Key.codigo_cliente, CuentaNombre = g.Key.nombre, Total = g.Count() }).ToList();
            }

            if (ClaseEstadistica == RedelexDTO.TipoEstadistica.TotalProcesosConsultadosCuenta)
            {
                _queryResult = (from a in context.auditoria_usuarios
                                join c in context.clientes on a.codigo_cliente equals c.codigo
                                where a.fecha_hora >= FechaInicial && a.fecha_hora <= DbFunctions.AddDays(FechaFinal, 1)
                                group a by new { a.codigo_cliente, c.nombre } into g
                                select new RedelexDTO.EstadisticasFecha { CuentaId = g.Key.codigo_cliente, CuentaNombre = g.Key.nombre, Total = g.Count() }).ToList();
            }

            
            return _queryResult;
        }

    }
}
