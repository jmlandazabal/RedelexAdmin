//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace RedelexDataModel
{
    using System;
    using System.Collections.Generic;
    
    public partial class grupos
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public grupos()
        {
            this.grupos_cuentas = new HashSet<grupos_cuentas>();
            this.usuarios = new HashSet<usuarios>();
        }
    
        public int id_grupo { get; set; }
        public string nombre { get; set; }
        public string descripcion { get; set; }
        public int id_tipo_grupo { get; set; }
        public bool eliminado { get; set; }
        public bool restringido { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<grupos_cuentas> grupos_cuentas { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<usuarios> usuarios { get; set; }
    }
}
