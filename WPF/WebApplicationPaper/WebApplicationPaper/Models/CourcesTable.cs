//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebApplicationPaper.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class CourcesTable
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CourcesTable()
        {
            this.offerd_courseTable = new HashSet<offerd_courseTable>();
        }
    
        public int crs_Id { get; set; }
        public string crs_name { get; set; }
        public string crs_title { get; set; }
        public int crs_pre_rac { get; set; }
        public int crs_crdt_hours { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<offerd_courseTable> offerd_courseTable { get; set; }
    }
}