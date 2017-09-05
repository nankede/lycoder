using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LYCoder.Entity;

namespace LYCoder.DataAccess
{
    public partial class LogAccess : BaseAccess<Sys_Log,Sys_LogFields>
    {

        public static Page<Sys_Log> GetList(long pageIndex, long pageSize, DateTime limitDate, string keyWord, string level = "")
        {
            Sql sql = Sql.Builder
                .Where("SLCreateTime > @0", limitDate.ToString())
                .Where("SLUserName like @0", '%' + keyWord + '%')
                .OrderBy("SLCreateTime desc");
            if (!string.IsNullOrEmpty(level))
            {
                sql.Where("SLLogLevel  =  @0", level);

            }
            return Db.Page<Sys_Log>(pageIndex, pageSize, sql);
        }

        public static int Delete(DateTime keepDate)
        {
            Sql sql = Sql.Builder.Where("SLCreateTime <= @0", keepDate.ToString());
            return Db.Delete<Sys_Log>(sql);
        }
    }
}
