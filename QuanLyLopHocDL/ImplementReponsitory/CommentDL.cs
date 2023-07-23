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
    public class CommentDL : BaseDL<comment>, ICommentDL
    {
        public CommentDL(IConfiguration configuration) : base(configuration)
        {
        }

        public IEnumerable<comment> GetComment(Guid id_schedule)
        {
            var dynamicParams = new DynamicParameters();
            dynamicParams.Add("@id_schedule", id_schedule);
            var sqlcmd = $"SELECT CONCAT(u.first_name ,' ', u.last_name) AS full_name,c.comment_content,c.comment_time FROM comment c INNER JOIN user u ON c.account_id = u.account_id WHERE c.schedule_id = @id_schedule ORDER BY c.comment_time ASC ";
            var data = connection.Query<comment>(sql: sqlcmd, param: dynamicParams).ToList();
            return data;
        }
    }
}
