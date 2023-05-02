using Dapper;
using Microsoft.Extensions.Configuration;
using MySqlConnector;
using QuanLyLopHocDL.IReponsitory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyLopHocDL.ImplementReponsitory
{
    public class BaseDL<Entity> : IDisposable, IBaseDL<Entity> where Entity : class
    {
        protected MySqlConnection connection;
        public readonly String connectionString = "";
        private String className = "";

        public BaseDL(IConfiguration configuration)
        {

            // Khởi tạo kết nối
            connectionString = configuration.GetConnectionString("AppConnectString");
            connection = new MySqlConnection(connectionString);
            connection.Open();
            className = typeof(Entity).Name;

        }

        public void Dispose()
        {
            connection.Close();
            connection.Dispose();
        }
        public IEnumerable<Entity> GetAll()
        {
            var sqlcmd = $"SELECT * FROM {className}";

            // thực hiện lấy dữ liệu 
            var data = connection.Query<Entity>(sql: sqlcmd);
            return data;
        }

        public Entity GetById(Guid id)
        {
            var sqlcmd = $"SELECT * FROM {className} WHERE {className}_id = @Id";
            var dynamicParams = new DynamicParameters();
            dynamicParams.Add("@Id", id);
            var data = connection.QueryFirstOrDefault<Entity>(sql: sqlcmd, param: dynamicParams);
            return data;
        }

        public int Update(Entity entity)
        {
            var sqlcmd = $"proc_update_{className}";
            var rowsEffec = connection.Execute(sql: sqlcmd, param: entity, commandType: System.Data.CommandType.StoredProcedure);
            return rowsEffec;
        }

        public int Insert(Entity entiy)
        {
            using (var transaction = connection.BeginTransaction())
            {
                var sqlcmd = $"proc_insert_{className}";
                var rowsEffec = connection.Execute(sql: sqlcmd, param: entiy, transaction: transaction, commandType: System.Data.CommandType.StoredProcedure);
                transaction.Commit();
                return rowsEffec;

            }
        }

        public int Delete(Guid id)
        {
            var sqlcmd = $"DELETE FROM {className} WHERE {className}_id = @id";
            var parameters = new DynamicParameters();
            parameters.Add("@id", id);
            var rowsEffec = connection.Execute(sql: sqlcmd, param: parameters);
            return rowsEffec;
        }

        public int DeleteMany(List<Guid> ids)
        {
            using (var transaction = connection.BeginTransaction())
            {
                try
                {
                    var parameters = new DynamicParameters();
                    parameters.Add("@id", ids);
                    var sqlcmd = $"DELETE FROM {className} WHERE {className}_id in @id";
                    var rowsEffec = connection.Execute(sql: sqlcmd, param: parameters, transaction: transaction);
                    if (rowsEffec == ids.Count)
                    {
                        transaction.Commit();
                    }
                    else
                    {
                        transaction.Rollback();
                        return 0;
                    }

                    return rowsEffec;
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    return 0;
                }
            }
        }
    }
}
