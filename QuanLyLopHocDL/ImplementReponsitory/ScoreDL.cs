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
                return rowsEffec;
            }
        }
    }
}
