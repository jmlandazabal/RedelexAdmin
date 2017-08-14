using RedelexDataModel;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedelexBLL
{

    public partial class Clientes:RedelexDTO.ClienteDetalleInfo
    {
        public static class Select
        {
            public static RedelexDTO.EstadisticasFecha GetTotalProcesosNuevos(DateTime FechaInicial, DateTime FechaFinal)
            {
                var x = RedelexDataModel.DALClientes.GetTotalProcesosNuevos(FechaInicial, FechaFinal);
                return x;

            }

            public static List<RedelexDTO.ClienteDetalleInfo> GetClientesPorLicencia(int? id)
            {
                var r = RedelexDataModel.DALClientes.GetClientesPorLicencia(id);
                return r;
            }

            public static RedelexDTO.ClienteDetalleInfo GetInfoCuenta(string id)
            {
                var r = RedelexDataModel.DALClientes.GetInfoCuenta(id);
                return r;
            }

            public static RedelexDTO.Estadisticas GetMovimientosVJConnect(string id, int v)
            {
                return RedelexDataModel.DALClientes.GetMovimientosVJConnect(id, v);
            }

            public static List<RedelexDTO.HTTP500Errors> GetAuditoria(string CuentaId, DateTime FechaIni, DateTime FechaFin)
            {
                return RedelexDataModel.DALClientes.GetHTTP500Errors(CuentaId, FechaFin, FechaFin);
            }
            public static List<RedelexDTO.HTTP500Errors> GetAuditoria(string CuentaId)
            {
                return RedelexDataModel.DALClientes.GetHTTP500Errors(CuentaId);


            }


        }
        public static class Update
        {
            public static int InfoBasica(RedelexDTO.ClienteDetalleInfo Cliente)
            {
                int _r = DALClientes.UpdateInfoBasica(Cliente);
                return 0;
            }
        }
    }
}
