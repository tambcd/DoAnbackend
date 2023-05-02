using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyLopHocDL.IReponsitory
{
    public interface IBaseDL<T>
    {
      
        public IEnumerable<T> GetAll();
        public T GetById(Guid id);
        public int Update(T entity);
        public int Insert(T entiy);
        public int Delete(Guid id);

        int DeleteMany(List<Guid> ids);


    }
}
