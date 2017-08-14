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
    
    public partial class ProcesosDS
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ProcesosDS()
        {
            this.ActuacionesDS = new HashSet<ActuacionesDS>();
        }
    
        public int IdProceso { get; set; }
        public string Radicacion { get; set; }
        public int IdCorporacion { get; set; }
        public string Ponente { get; set; }
        public string Despacho { get; set; }
        public string Tipo { get; set; }
        public string Clase { get; set; }
        public string ContenidoRadicacion { get; set; }
        public string UbicacionExpediente { get; set; }
        public bool Eliminado { get; set; }
        public decimal obligacion { get; set; }
        public System.DateTime FechaInsercion { get; set; }
        public int UsuarioInsercion { get; set; }
        public Nullable<System.DateTime> FechaEliminacion { get; set; }
        public Nullable<int> UsuarioEliminacion { get; set; }
        public Nullable<int> UltimaActuacionDS { get; set; }
        public Nullable<System.DateTime> FechaUltimaConsulta { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ActuacionesDS> ActuacionesDS { get; set; }
        public virtual procesos procesos { get; set; }
    }
}
