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
    public class AccountBL : BaseBL<account>, IAccountBL
    {
        IAccountDL _accountDL;
        public AccountBL(IAccountDL accountDL) : base(accountDL)
        {
            _accountDL = accountDL;
        }
    }
}
