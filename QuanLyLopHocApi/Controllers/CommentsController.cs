using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QuanLyLopHocBL.IService;
using QuanLyLopHocCommon.Entity;
using QuanLyLopHocDL.IReponsitory;

namespace QuanLyLopHocApi.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class CommentsController : BasesController<comment>
    {
        private ICommentBL _commentBL;
        private ICommentDL _commentDL;
        public CommentsController(ICommentDL commentDL, ICommentBL commentBL) : base(commentDL, commentBL)
        {
            _commentDL = commentDL;
            _commentBL = commentBL;
        }
        [HttpGet("CommentBySchedule")]
        public IActionResult CommentBySchedule(Guid id_schedule)
        {
            try
            {
                var data = _commentDL.GetComment(id_schedule);
                return Ok(data);
            }
            catch (Exception ex)
            {
                return HandelException(ex);
            }

        }
    }
}
