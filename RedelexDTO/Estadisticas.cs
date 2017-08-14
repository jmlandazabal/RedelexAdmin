using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedelexDTO
{
    public static class TipoEstadistica
    {
        public const string TotalProcesosNuevos = "TotalProcesosNuevos";
        public const string TotalActuacionesNuevas = "TotalActuacionesNuevas";
        public const string TotalUsuariosActivos = "TotalUsuariosActivos";
        public const string TotalProcesosConsultados = "TotalProcesosConsultados";
        public const string TotalProcesosConsultadosCuenta = "TotalProcesosConsultadosCuenta";
        public const string TotalProcesosCreadosCuenta = "TotalProcesosCreadosCuenta";
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
                return _fecha.ToString("dddd", new CultureInfo("es-ES"));
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

    public class Estadisticas
    {
        public Estadisticas(int Dias)
        {
            
            this._fechaFin = DateTime.Now;
            this._fechaIni = DateTime.Now.AddDays(Dias * -1);


        }

        private DateTime _fechaIni;
        public DateTime FechaIni { get => _fechaIni; set => _fechaIni = value; }

        private DateTime _fechaFin;
        public DateTime FechaFin { get => _fechaFin; set => _fechaFin = value; }

        private string _fechaIniString;

        private string _fechaFinString;

        public List<RedelexDTO.EstadisticasFecha> Estadistica { get; set; }
        public string FechaIniString { get => _fechaIni.ToString("yyyy-MM-dd");}
        public string FechaFinString { get => _fechaFin.ToString("yyyy-MM-dd");}
        
    }
}