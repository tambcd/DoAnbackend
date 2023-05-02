using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyLopHocCommon.Entity
{
    public class account_chat
    {
        public Guid chat_room_id { get; set; }
        public Guid account_id { get; set; }
        public int role { get; set; }   
    }
}
