using QuanLyLopHocCommon.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyLopHocDL.IReponsitory
{
    public interface ICommentDL: IBaseDL<comment>
    {
        public IEnumerable<comment> GetComment(Guid id_schedule);
    }
}
