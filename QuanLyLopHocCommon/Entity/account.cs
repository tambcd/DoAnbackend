using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyLopHocCommon.Entity
{
    public class account
    {
        public Guid account_id { get; set; }
        public string account_name { get; set;}

        public string password { get; set;}
        public int role { get; set; }

    }
}
