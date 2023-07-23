using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QuanLyLopHocBL.IService;
using QuanLyLopHocCommon.Entity;
using QuanLyLopHocDL.IReponsitory;

namespace QuanLyLopHocApi.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class MessagesController : BasesController<message>
    {
        private IMessageBL _messageBL;
        private IMessageDL _messageDL;
        public MessagesController(IMessageDL messageDL, IMessageBL messageBL) : base(messageDL, messageBL)
        {
            _messageDL = messageDL;
            _messageBL = messageBL;
        }
    }
}
