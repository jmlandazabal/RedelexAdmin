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
    
    public partial class ProcesosTYBA
    {
        public int ProcesoIdTYBA { get; set; }
        public string id_cuenta { get; set; }
        public decimal obligacion { get; set; }
        public string Radicacion { get; set; }
        public bool Eliminado { get; set; }
    
        public virtual procesos procesos { get; set; }
    }
}
