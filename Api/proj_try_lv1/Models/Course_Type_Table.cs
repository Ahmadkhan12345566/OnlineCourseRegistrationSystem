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
    
    public partial class Course_Type_Table
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Course_Type_Table()
        {
            this.Courses_Table = new HashSet<Courses_Table>();
        }
    
        public int type_id { get; set; }
        public string type_name_ { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Courses_Table> Courses_Table { get; set; }
    }
}
