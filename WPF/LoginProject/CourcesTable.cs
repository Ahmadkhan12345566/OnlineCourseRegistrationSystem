using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginProject
{
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
