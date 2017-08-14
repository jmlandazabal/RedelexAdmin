using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RedelexDataModel;
using System.Globalization;

namespace RedelexBLL
{
    public partial class Clientes
    {
        public class ClientesDetalleInfo : RedelexDTO.ClienteDetalleInfo
        {
            public ClientesDetalleInfo()
            {
                this.LicenciaInfo = new RedelexDTO.Licencia();
            }

            public ClientesDetalleInfo(string CuentaId)
            {
                GetDetalleInfo(CuentaId);
            }

            private void GetDetalleInfo(string CuentaId)
            {
                this.CuentaId = CuentaId;
                this.TotalProcesos = this.TotalProcesosActivos = this.TotalProcesosInactivos = this.TotalProcesosEliminados = 0;
                this.LicenciaInfo = new  RedelexDTO.Licencia();
                this.AuditoriaUsuarios = new List<RedelexDTO.AuditoriaUsuario>();

                this.AuditoriaUsuarios = RedelexDataModel.DALClientes.GetAuditoriaUsuarios(CuentaId);

                RedelexDTO.ClienteDetalleInfo _q2 = new RedelexDTO.ClienteDetalleInfo();

                _q2 = RedelexDataModel.DALClientes.GetInfoCuenta(CuentaId);

                // Datos Generales
                this.NombreCuenta = _q2.NombreCuenta;
                this.RepositorioDocumentos = _q2.RepositorioDocumentos;
                this.Activo = _q2.Activo;

                //Licencia
                this.LicenciaInfo.MaximoEspacioDisco = _q2.LicenciaInfo.MaximoEspacioDisco;
                this.LicenciaInfo.MaximoProcesos = _q2.LicenciaInfo.MaximoProcesos;
                this.LicenciaInfo.VJConnectMaximoProcesos = _q2.LicenciaInfo.VJConnectMaximoProcesos;
                this.LicenciaInfo.TipoLicenciaId = _q2.LicenciaInfo.TipoLicenciaId;
                this.LicenciaInfo.TipoLicenciaNombre = _q2.LicenciaInfo.TipoLicenciaNombre;
                this.LicenciaInfo.LicenseKey = _q2.LicenciaInfo.LicenseKey;
                this.LicenciaInfo.FechaExpiracion = _q2.LicenciaInfo.FechaExpiracion;

                // Totales
                this.TotalProcesos = RedelexDataModel.DALClientes.GetTotalProcesos(CuentaId);
                this.TotalProcesosActivos = RedelexDataModel.DALClientes.GetTotalProcesosActivos(CuentaId);
                this.TotalProcesosInactivos = RedelexDataModel.DALClientes.GetTotalProcesosInactivos(CuentaId);
                this.TotalProcesosConVJConnect = RedelexDataModel.DALClientes.GetTotalProcesosConVJConnects(CuentaId);

                // Auditoria
                this.AuditoriaUsuarios = RedelexDataModel.DALClientes.GetAuditoriaUsuarios(CuentaId);

            }

            


        }

    }

}
