using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedelexBLL
{
    public class Estadisticas
    {
        
        public static List<RedelexDTO.EstadisticasFecha> GetEstadisticas(int Dias, string TipoEstadistica)
        {
            List<RedelexDTO.EstadisticasFecha> _ret = new List<RedelexDTO.EstadisticasFecha>();
            _ret = RedelexDataModel.DALEstadisticas.GetEstadisticas(Dias, TipoEstadistica);
            
            return _ret;
        }
    }
}
