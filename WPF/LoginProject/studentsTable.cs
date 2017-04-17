using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginProject
{
    public partial class studentsTable
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public studentsTable()
        {
            this.registerd_crs_Table = new HashSet<registerd_crs_Table>();
        }

        public int std_Id { get; set; }
        public string std_name { get; set; }
        public string std_deprt { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<registerd_crs_Table> registerd_crs_Table { get; set; }
    }
}
