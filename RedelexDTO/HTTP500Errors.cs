using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedelexDTO
{
    public class HTTP500Errors
    {
        public int Id { get; set; }
        //public DateTime FechaHora { get; set; }
        public string Url { get; set; }
        public string AspDesc { get; set; }
        public string AspNumber { get; set; }
        public int AspLine { get; set; }
        public int AspColumn { get; set; }
        public string ErrDesc { get; set; }
        public string ErrNumber { get; set; }
        public string Ref { get; set; }
        public string Ip { get; set; }
        public string Ua { get; set; }
        public string Method { get; set; }
        public string Data { get; set; }
        public string CuentaId { get; set; }
        public int? UsuarioId { get; set; }
        public string UsuarioNombre { get; set; }
        public string CuentaNombre { get; set; }

        private DateTime _fechaHora;
        public DateTime FechaHora { get => _fechaHora; set => _fechaHora = value; }

        private string _fechaHoraString;
        public string FechaHoraString { get => _fechaHora.ToString("yyyy-MM-dd HH:mm:ss"); }

    }
}
