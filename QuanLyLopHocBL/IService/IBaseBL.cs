using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyLopHocBL.IService
{
    public interface IBaseBL<T>
    {
        public int InsertSevices(T entity);
        public int UpdateSevices(T entity);
        public bool Validate(T entity);



    }
}
