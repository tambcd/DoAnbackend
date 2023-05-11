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
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string gender { get; set; }
        public string? countryside { get; set; }
        public DateTime date_of_birth { get; set; }
        public string? email { get; set; }
        public string? phone_number { get; set; }
        public int status { get; set; }
        public Guid account_id { get; set; }
        public string user_code { get; set; }
    }
}
