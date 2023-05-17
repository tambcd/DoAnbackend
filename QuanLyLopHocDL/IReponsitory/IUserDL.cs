using QuanLyLopHocCommon.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyLopHocDL.IReponsitory
{
    public interface IUserDL: IBaseDL<user>
    {
        public IEnumerable<user> GetUserByClass(Guid idClass, string? txtSearch, int PageSize, int PageNumber);

    }
}
