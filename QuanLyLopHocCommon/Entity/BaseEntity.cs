using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyLopHocCommon.Entity
{
    public class BaseEntity
    {
        public DateTime? created_day { get; set; }
        public DateTime? modify_day { get; set; }
    }
}
