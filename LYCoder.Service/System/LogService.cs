using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LYCoder.Common;
using LYCoder.Entity;
using LYCoder.DataAccess;

namespace LYCoder.Service
{
    public partial class LogService : BaseService<Sys_Log, Sys_LogFields>
    {
        public static Page<Sys_Log> GetList(long pageIndex, long pageSize, DateTime limitDate, string keyWord,string level)
        {
            return LogAccess.GetList(pageIndex, pageSize, limitDate, keyWord, level);
        }

        public static int Delete(DateTime keepDate)
        {
            return LogAccess.Delete(keepDate);
        }
    }
}
