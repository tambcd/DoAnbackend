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
    public class CommentBl : BaseBL<comment>, ICommentBL
    {
        ICommentDL _commentDL;
        public CommentBl(ICommentDL commentDL) : base(commentDL)
        {
            _commentDL = commentDL;
        }
    }
}
