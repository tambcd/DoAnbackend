using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyLopHocCommon.Entity
{
    public class schedule : BaseEntity 
    {
        public Guid schedule_id { get; set; }
        [Required]
        public string schedule_name { get; set; }  
        [Required]
        public string color_code { get; set; }
        public DateTime time_show { get; set; }
        public DateTime time_start { get; set; }
        public DateTime time_end { get; set; }
        [Required]
        public int schedule_type { get; set; }
        public Guid class_room_id { get; set; }  
        public Guid account_id { get; set; }  

    }
}
