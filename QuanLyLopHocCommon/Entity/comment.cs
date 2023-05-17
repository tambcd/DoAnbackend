using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyLopHocCommon.Entity
{
    public class comment
    {
        public Guid comment_id { get; set; }
        public Guid schedule_id { get; set; }
        public Guid account_id { get; set; }
        public string comment_content { get; set; }
        public DateTime comment_time { get; set; }
        
    }
}
