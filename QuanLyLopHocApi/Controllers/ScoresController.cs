using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QuanLyLopHocBL.IService;
using QuanLyLopHocCommon.Entity;
using QuanLyLopHocDL.IReponsitory;

namespace QuanLyLopHocApi.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ScoresController : BasesController<score>
    {
        private IScoreBL _scoreBL;
        private IScoreDL _scoreDL;
        public ScoresController(IScoreDL scoreDL, IScoreBL scoreBL) : base(scoreDL, scoreBL)
        {
            _scoreDL = scoreDL;
            _scoreBL = scoreBL;
        }

        /// <summary>
        /// nhập khẩu từ excel
        /// @created by : tvTam
        /// @create day : 19/3/2023
        /// </summary>
        /// <param name="formFile">tệp chứa thông tin nhập khẩu </param>
        /// <returns>số bản ghi đươc nhập khẩu </returns>
        [HttpPost("Import")]
        public IActionResult Import(IFormFile formFile)
        {
            try
            {
                var path = _scoreBL.ImportScores(formFile);
                return Ok(path);
            }
            catch (Exception ex)
            {
                return HandelException(ex);
            }

        }
    }
}
