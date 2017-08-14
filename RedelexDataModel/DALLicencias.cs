using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedelexDataModel
{

    public static partial class DALLicencias
    {
        public static string GetTipoLicencia(int? id)
        {
            RedelexEntities db = new RedelexEntities();
            return (from a in db.TipoLicencias where a.TipoLicenciaId == id select a.TipoLicencia).FirstOrDefault();
        }
    }
}
