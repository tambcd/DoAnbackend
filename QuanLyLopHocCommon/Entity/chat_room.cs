using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyLopHocCommon.Entity
{
    public class chat_room
    {
        public Guid chat_room_id { get; set; }
        public string chat_room_name { get; set;}
        public Guid class_id { get; set; }
    }
}
