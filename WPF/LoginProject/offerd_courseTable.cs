using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginProject
{
      public partial class offerd_courseTable
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public offerd_courseTable()
        {
            this.registerd_crs_Table = new HashSet<registerd_crs_Table>();
        }
    
        public int offerd_crs_Id { get; set; }
        public int crs_id { get; set; }
        public string session { get; set; }
    
        public virtual CourcesTable CourcesTable { get; set; }
     //   [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<registerd_crs_Table> registerd_crs_Table { get; set; }
    }
}
