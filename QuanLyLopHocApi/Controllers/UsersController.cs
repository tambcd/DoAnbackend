using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QuanLyLopHocBL.IService;
using QuanLyLopHocCommon.Entity;
using QuanLyLopHocDL.IReponsitory;

namespace QuanLyLopHocApi.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class UsersController : BasesController<user>
    {

        private IUserBL _userBL;
        private IUserDL _userDL;
        public UsersController(IUserDL epository, IUserBL userBL) : base(epository, userBL)
        {
            _userBL = userBL;
            _userDL = epository;
        }
    }
}
