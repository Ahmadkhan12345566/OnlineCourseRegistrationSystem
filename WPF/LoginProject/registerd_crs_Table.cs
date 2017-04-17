using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginProject
{
    public partial class registerd_crs_Table
    {
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public int reg_crs_Id { get; set; }
        public int std_id { get; set; }
        public int offer_crs_id { get; set; }
        public string status { get; set; }

        public virtual offerd_courseTable offerd_courseTable { get; set; }
        public virtual studentsTable studentsTable { get; set; }
    }
}
