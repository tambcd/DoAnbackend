using QuanLyLopHocCommon.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyLopHocDL.IReponsitory
{
    public interface IScoreDL: IBaseDL<score>
    {
        /// <summary>
        /// nhập khâủ dữ liệu 
        /// @created by : tvTam
        /// </summary>
        /// <param name="scores">danh sách điểm </param>
        /// <returns>số bản ghi thành công || thất bại : 0</returns>
        public int Import(List<score> scores);


        public IEnumerable<score> GetScoresByFilter(int PageNumber, int PageSize, string? txtSearch, string? codeUser, string? schoolYear, int? semester);
    }
}
