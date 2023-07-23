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
        [HttpGet("getClass")]
        public IActionResult GetByCLass(Guid idClass, string? txtSearch, int PageSize, int PageNumber)
        {
            try
            {
                var data = _userDL.GetUserByClass(idClass,txtSearch,PageSize, PageNumber);
                return Ok(data);
            }
            catch (Exception ex)
            {
                return HandelException(ex);
            }

        }
     /*   [HttpGet("getReport")]
        public IActionResult getReport()
        {
            try
            {
                var data = _userDL.GetReport();
                return Ok(data);
            }
            catch (Exception ex)
            {
                return HandelException(ex);
            }

        }*/
        [HttpGet("getByIdAccount/{idAccount}")]
        public IActionResult GetByIdAccount(Guid idAccount)
        {
            try
            {
                var data = _userDL.GetUserByIdAccount(idAccount);
                return Ok(data);
            }
            catch (Exception ex)
            {
                return HandelException(ex);
            }

        }


    }
}
