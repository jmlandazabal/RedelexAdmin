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
    
    public partial class ActuacionesDS
    {
        public int IdActuacion { get; set; }
        public int IdProceso { get; set; }
        public string FechaAct { get; set; }
        public string Actuacion { get; set; }
        public string Anotacion { get; set; }
        public string IniciaTermino { get; set; }
        public string FinTermino { get; set; }
        public string Registro { get; set; }
        public Nullable<System.DateTime> FechaInsercion { get; set; }
        public bool Eliminado { get; set; }
        public Nullable<System.DateTime> FechaActDate { get; set; }
        public Nullable<System.DateTime> IniciaTerminoDate { get; set; }
        public Nullable<System.DateTime> FinTerminoDate { get; set; }
        public Nullable<System.DateTime> RegistroDate { get; set; }
        public Nullable<int> UltimaActuacionDS { get; set; }
    
        public virtual ProcesosDS ProcesosDS { get; set; }
    }
}
