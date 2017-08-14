using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RedelexDataModel;

namespace RedelexBLL
{
    public class Licencias
    {
        public static class Select
        {
            public static string TipoLicencia(int? id)
            {

                string tipoLicencia = RedelexDataModel.DALLicencias.GetTipoLicencia(id);
                return tipoLicencia;
            }
        }
    }
}