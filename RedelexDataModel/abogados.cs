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
    
    public partial class abogados
    {
        public string abogado { get; set; }
        public string nombre1 { get; set; }
        public string nombre2 { get; set; }
        public string apellido1 { get; set; }
        public string apellido2 { get; set; }
        public string cedula { get; set; }
        public string especialidad { get; set; }
        public Nullable<int> tipo_vinculacion { get; set; }
        public Nullable<System.DateTime> fecha_contrato { get; set; }
        public string direccion_residencia { get; set; }
        public string telefono_residencia { get; set; }
        public string direccion_oficina { get; set; }
        public string telefono_oficina { get; set; }
        public Nullable<int> departamento { get; set; }
        public int ciudad { get; set; }
        public string apartado_aereo { get; set; }
        public Nullable<int> total_casos { get; set; }
        public Nullable<int> regional { get; set; }
        public string observacion { get; set; }
        public Nullable<System.DateTime> fecha_actualizacion { get; set; }
        public string tarjeta { get; set; }
        public Nullable<short> tipo_regimen { get; set; }
        public string correo { get; set; }
        public string nombre { get; set; }
        public string tipo_abogado { get; set; }
        public bool eliminado { get; set; }
        public int id_abogado { get; set; }
        public string id_cuenta { get; set; }
        public bool activo { get; set; }
        public string telefono_celular { get; set; }
        public Nullable<int> usuario_asociado { get; set; }
    }
}