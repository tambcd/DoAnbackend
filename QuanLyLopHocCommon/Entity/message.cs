using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyLopHocCommon.Entity
{
    public class message
    {
        public Guid message_id { get; set; }
        public string content { get; set; }
        public DateTime created_day { get; set; }
        public Guid account_id { get; set; }
        public Guid chat_room_id { get; set; }
    }
}
