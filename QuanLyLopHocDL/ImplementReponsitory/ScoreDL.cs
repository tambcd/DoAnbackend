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
    public class ScoreDL : BaseDL<score>, IScoreDL
    {
        public ScoreDL(IConfiguration configuration) : base(configuration)
        {
        }

        public IEnumerable<score> GetScoresByFilter(int PageNumber,int PageSize,string? txtSearch,string? codeUser,string? schoolYear,int? semester)
        {
            if (txtSearch == null)
            {
                txtSearch = "";
            }
            var sqlcmd = $"proc_ft_score";
            var dynamicParams = new DynamicParameters();
            dynamicParams.Add("@PageNumber", PageNumber);
            dynamicParams.Add("@PageSize", PageSize);
            dynamicParams.Add("@txtSearch", txtSearch);
            dynamicParams.Add("@codeUser", codeUser);
            dynamicParams.Add("@schoolYear", schoolYear);
            dynamicParams.Add("@semester", semester);

            var data = connection.Query<score>(sql: sqlcmd, param: dynamicParams, commandType: System.Data.CommandType.StoredProcedure).ToList();
            return data;
            

        }

        public int Import(List<score> scores)
        {
            var rowsEffec = 0;
            using (var transaction = connection.BeginTransaction())
            {
                var sqlcmd = $"proc_insert_score";
                foreach (var score in scores)
                {
                    rowsEffec += connection.Execute(sql: sqlcmd, param: score, transaction: transaction, commandType: System.Data.CommandType.StoredProcedure);
                }
                if (rowsEffec == scores.Count())
                {
                    transaction.Commit();
                    return rowsEffec;

                }
                transaction.Rollback();
                return 0;
            }
        }
    }
}
