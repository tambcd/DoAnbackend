using Dapper;
using Microsoft.Extensions.Configuration;
using QuanLyLopHocCommon.Entity;
using QuanLyLopHocDL.IReponsitory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyLopHocDL.ImplementReponsitory
{
    public class UserDL : BaseDL<user>, IUserDL
    {
        public UserDL(IConfiguration configuration) : base(configuration)
        {

        }

        public IEnumerable<user> GetUserByClass(Guid idClass,string? txtSearch , int PageSize, int PageNumber)
        {
            if (txtSearch == null)
            {
                txtSearch = "";
            }
            var sqlcmd = $"proc_ft_user";
            var dynamicParams = new DynamicParameters();
            dynamicParams.Add("@idClass", idClass);
            dynamicParams.Add("@txtSearch", txtSearch);
            dynamicParams.Add("@PageSize", PageSize);
            dynamicParams.Add("@PageNumber", PageNumber);

            var data = connection.Query<user>(sql: sqlcmd, param: dynamicParams, commandType: System.Data.CommandType.StoredProcedure).ToList();
            return data;
        }
    }
}
