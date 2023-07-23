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
        [HttpGet("login")]
        public IActionResult Login(string username, string password)
        {
            try
            {
                var data = _accountDL.Login(username, password);
                return Ok(data);
            }
            catch (Exception ex)
            {
                return HandelException(ex);
            }

        }
        [HttpPost("CreateUser")]
        public IActionResult CreateUser(AccountUser user)
        {
            try
            {
                var data = _accountDL.InsertAccount(user);
                return Ok(data);
            }
            catch (Exception ex)
            {
                return HandelException(ex);
            }

        }
    }
}
