using QuanLyLopHocBL.IService;
using QuanLyLopHocCommon.Entity;
using QuanLyLopHocDL.IReponsitory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyLopHocBL.ImplementService
{
    public class ScheduleBL : BaseBL<schedule>, IScheduleBL
    {
        IScheduleDL _scheduleDL;
        public ScheduleBL(IScheduleDL scheduleDL) : base(scheduleDL)
        {
            _scheduleDL = scheduleDL;
        }
    }
}
