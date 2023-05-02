using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyLopHocCommon.Entity
{
    public class user
    {
        public Guid user_id { get; set; }
        public string full_name { get; set; }
        public string email { get; set; }
        public string phone_number { get; set; }
        public int status { get; set; }
        public Guid account_id { get; set; }
        public string user_code { get; set; }
    }
}
