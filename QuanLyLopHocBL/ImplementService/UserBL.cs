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
    public class UserBL : BaseBL<user>, IUserBL
    {
        IUserDL _userDL;
        public UserBL(IUserDL userDL) : base(userDL)
        {
            _userDL = userDL;
        }
    }
}
