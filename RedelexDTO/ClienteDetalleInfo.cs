using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedelexDTO
{
    public class ClienteDetalleInfo : Cliente
    {
        public int TotalProcesos { get; set; }
        public int TotalProcesosActivos { get; set; }
        public int TotalProcesosInactivos { get; set; }
        public int TotalProcesosEliminados { get; set; }
        public int TotalProcesosConVJConnect { get; set; }
        public List<AuditoriaUsuario> AuditoriaUsuarios { get; set; }
        public List<HTTP500Errors> HTTP500Errors { get; set;}

        public ClienteDetalleInfo()
        {
            this.LicenciaInfo = new Licencia();
            this.AuditoriaUsuarios = new List<AuditoriaUsuario>();
        }

    }
    
}
