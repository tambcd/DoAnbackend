using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QuanLyLopHocBL.IService;
using QuanLyLopHocCommon.Entity;
using QuanLyLopHocDL.IReponsitory;

namespace QuanLyLopHocApi.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class AccountsController : BasesController<account>
    {
        private IAccountBL _accountBL;
        private IAccountDL _accountDL;
        public AccountsController(IAccountDL epository, IAccountBL baseBL) : base(epository, baseBL)
        {
            _accountBL = baseBL;
            _accountDL = epository;
        }
    }
}
