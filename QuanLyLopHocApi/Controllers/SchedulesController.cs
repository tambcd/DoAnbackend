using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QuanLyLopHocBL.IService;
using QuanLyLopHocCommon.Entity;
using QuanLyLopHocDL.IReponsitory;

namespace QuanLyLopHocApi.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class SchedulesController : BasesController<schedule>
    {
        private IScheduleBL _scheduleBL;
        private IScheduleDL _scheduleDL;
        public SchedulesController(IScheduleDL scheduleDL, IScheduleBL scheduleBL) : base(scheduleDL, scheduleBL)
        {
        }
    }
}
