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
    public class AccountDL : BaseDL<account>, IAccountDL
    {
        public AccountDL(IConfiguration configuration) : base(configuration)
        {
        }

        public int InsertAccount(AccountUser account)
        {
            using (var transaction = connection.BeginTransaction())
            {
                var sqlcmd = $"proc_insert_account";
                var rowsEffec = connection.Execute(sql: sqlcmd, param: account.userAccount, transaction: transaction, commandType: System.Data.CommandType.StoredProcedure);
                if(rowsEffec != null)
                {
                    var sqlcmds = $"proc_insert_user";
                    var data = connection.Execute(sql: sqlcmds, param: account.user, transaction: transaction, commandType: System.Data.CommandType.StoredProcedure);
                    transaction.Commit();
                    return data;

                }
            }
            return 0;
        }

        public account Login(string username, string password)
        {
           
            var dynamicParams = new DynamicParameters();
            dynamicParams.Add("@username", username);
            dynamicParams.Add("@password", password);
            var sqlcmd = $"SELECT * FROM account a WHERE a.account_name = @username AND a.password = @password ";
            var data = connection.QueryFirstOrDefault<account>(sql: sqlcmd, param: dynamicParams);
            return data;
        }
    }
}
