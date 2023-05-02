using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MISA.Common.Exceptions;
using QuanLyLopHocBL.IService;
using QuanLyLopHocDL.IReponsitory;

namespace QuanLyLopHocApi.Controllers
{
    [ApiController]
    public class BasesController<Entity> : ControllerBase
    {
        protected IBaseDL<Entity> _baseDL;
        protected IBaseBL<Entity> _baseBL;
        public BasesController(IBaseDL<Entity> epository, IBaseBL<Entity> baseBL)
        {
            _baseDL = epository;
            _baseBL = baseBL;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                var data = _baseDL.GetAll();
                return Ok(data);
            }
            catch (Exception e)
            {
                return HandelException(e);
            }
        }
        /// <summary>
        /// Lấy phòng ban theo ID
        /// @createdby : TVTam
        /// </summary>
        /// <param name="id"> khóa chính </param>
        /// <returns>1 đối tượng </returns>
        /// 
        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            try
            {
                var data = _baseDL.GetById(id);
                if (data != null)
                {

                    return StatusCode(200, data);

                }
                else
                {
                    return NotFound();
                }

            }
            catch (Exception ex)
            {
                return HandelException(ex);
            }
        }

        /// <summary>
        /// Thêm phòng ban 
        /// @createdby : TVTam
        /// </summary>
        /// <param name="entity"> đối tượng thêm mới</param>
        /// <returns>201 thành công ||Exception từng trường hợp </returns>
        [HttpPost]
        public IActionResult Post(Entity entity)
        {
            try
            {
                var data = _baseBL.InsertSevices(entity);
                if (data == 1)
                {
                    return StatusCode(201, data);
                }
                else { return BadRequest(); }

            }
            catch (Exception ex)
            {

                return HandelException(ex);

            }
        }

        [HttpPut("{id}")]
        public IActionResult Put(Guid id, Entity entity)
        {
            try
            {
                var data = _baseBL.UpdateSevices(entity);
                return StatusCode(200, data);

            }
            catch (Exception ex)
            {

                return HandelException(ex);
            }
        }


        [NonAction]
        public IActionResult HandelException(Exception ex)
        {
            var res = new
            {
                devMsg = ex.Message,
                userMsg = QuanLyLopHocCommon.CommonResource.GetResoureString("ErrorSystem"),
                erros = ex.Data["ListValidate"],

            };
            if (ex is CustomException)
            {
                return BadRequest(res);
            }
            return StatusCode(500, res);

        }

    }
}
