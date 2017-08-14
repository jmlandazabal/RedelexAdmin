using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedelexDTO
{

    public class Cliente
    {

        public string CuentaId { get; set; }

        public string NombreCuenta { get; set; }

        public bool Activo { get; set; }

        public string RepositorioDocumentos { get; set; }

        public DateTime? FechaExpiracion
        {
            get
            {
                return _licenciaInfo.FechaExpiracion;
            }
        }

        public Licencia LicenciaInfo { get => _licenciaInfo; set => _licenciaInfo = value; }

        private Licencia _licenciaInfo;

        //public Licencia LicenciaInfo { get; set; }

    }
    public class Licencia
    {
        public int MaximoUsuarios { get; set; }
        public decimal MaximoProcesos { get; set; }
        public int VJConnectMaximoProcesos { get; set; }
        public decimal MaximoEspacioDisco { get; set; }

        private DateTime? _fechaExpiracion;
        public DateTime? FechaExpiracion
        {
            get
            {
                return _fechaExpiracion;
            }
            set
            {
                _fechaExpiracion = value;
            }
        }

        public string FechaExpiracionString
        {
            get
            {
                if (_fechaExpiracion.HasValue)
                    return _fechaExpiracion.Value.ToString("yyyy-MM-dd");
                return "-- SIN FECHA --";

            }
        }

        public int TipoLicenciaId { get; set; }
        public string TipoLicenciaNombre { get; set; }
        public Guid LicenseKey { get; set; }
        

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

    public class TipoLicencia
    {
        public int TipoLicenciaId { get; set; }
        public string TipoLicenciaNombre { get; set; }
    }
}
