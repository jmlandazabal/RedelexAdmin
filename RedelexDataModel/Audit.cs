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
    
    public partial class Audit
    {
        public int AuditID { get; set; }
        public string Type { get; set; }
        public string TableName { get; set; }
        public string PrimaryKeyField { get; set; }
        public string PrimaryKeyValue { get; set; }
        public string FieldName { get; set; }
        public string OldValue { get; set; }
        public string NewValue { get; set; }
        public Nullable<System.DateTime> UpdateDate { get; set; }
        public string UserName { get; set; }
    }
}
