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
    public class MessageBL : BaseBL<message>, IMessageBL
    {
        IMessageDL _messageDL;
        public MessageBL(IMessageDL messageDL) : base(messageDL)
        {
            _messageDL = messageDL;
    }
    }
}
