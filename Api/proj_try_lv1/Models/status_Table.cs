//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace proj_try_lv1.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class status_Table
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public status_Table()
        {
            this.Registerd_courses_Table = new HashSet<Registerd_courses_Table>();
        }
    
        public int status_Id { get; set; }
        public string status_title { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Registerd_courses_Table> Registerd_courses_Table { get; set; }
    }
}