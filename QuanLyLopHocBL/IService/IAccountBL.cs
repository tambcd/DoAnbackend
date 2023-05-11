using Microsoft.AspNetCore.Http;
using QuanLyLopHocCommon.Entity;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyLopHocBL.IService
{
    public interface IAccountBL: IBaseBL<account>
    {   
        /// <summary>
        /// nhập khẩu tài khoản 
        /// </summary>
        /// <param name="file">tệp danh sách tài khoản</param>
        /// <returns>số tài khoản được nhập khẩu</returns>
        public int ImportAccout(IFormFile file);
    }
}
