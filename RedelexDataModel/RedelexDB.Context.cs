﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class RedelexEntities : DbContext
    {
        public RedelexEntities()
            : base("name=RedelexEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<abogados> abogados { get; set; }
        public virtual DbSet<acciones_usuarios> acciones_usuarios { get; set; }
        public virtual DbSet<actuaciones_judiciales> actuaciones_judiciales { get; set; }
        public virtual DbSet<ActuacionesDS> ActuacionesDS { get; set; }
        public virtual DbSet<Audit> Audit { get; set; }
        public virtual DbSet<auditoria_usuarios> auditoria_usuarios { get; set; }
        public virtual DbSet<AuditoriaDS> AuditoriaDS { get; set; }
        public virtual DbSet<clientes> clientes { get; set; }
        public virtual DbSet<grupos> grupos { get; set; }
        public virtual DbSet<grupos_cuentas> grupos_cuentas { get; set; }
        public virtual DbSet<HTTP500Errors> HTTP500Errors { get; set; }
        public virtual DbSet<procesos> procesos { get; set; }
        public virtual DbSet<ProcesosDS> ProcesosDS { get; set; }
        public virtual DbSet<ProcesosTYBA> ProcesosTYBA { get; set; }
        public virtual DbSet<Productos> Productos { get; set; }
        public virtual DbSet<tipo_estados> tipo_estados { get; set; }
        public virtual DbSet<TipoLicencias> TipoLicencias { get; set; }
        public virtual DbSet<tokens> tokens { get; set; }
        public virtual DbSet<usuarios> usuarios { get; set; }
        public virtual DbSet<usuarios_grupos> usuarios_grupos { get; set; }
        public virtual DbSet<v_usuarios_cuentas> v_usuarios_cuentas { get; set; }
    }
}