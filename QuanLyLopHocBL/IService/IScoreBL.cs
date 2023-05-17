using Microsoft.AspNetCore.Http;
using QuanLyLopHocCommon.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyLopHocBL.IService
{
    public interface IScoreBL : IBaseBL<score>
    {
        /// <summary>
        /// Nhập khẩu danh sách điểm theo kì 
        /// (TVTam - 26/04/03 )
        /// </summary>
        /// <param name="file">file excel đầu vào</param>
        /// <returns> danh sách tài sản hợp lệ</returns>
        public int  ImportScores(IFormFile file);
    }
}
