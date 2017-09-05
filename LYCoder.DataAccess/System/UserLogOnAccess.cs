using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LYCoder.Entity;

namespace LYCoder.DataAccess
{
    public partial class UserLogOnAccess : BaseAccess<Sys_Userlogon, Sys_UserlogonFields>
    {
        public static Sys_Userlogon GetByAccount(int userId)
        {
            return Db.FirstOrDefault<Sys_Userlogon>("where SULUserId=@0", userId);
        }

        public static int Delete(params string[] userIds)
        {
            Sql sql = Sql.Builder.Append(" WHERE");
            for (int i = 0; i < userIds.Length - 1; i++)
            {
                sql.Append(" SULUserId=@0 OR", userIds[i]);
            }
            sql.Append(" SULUserId=@0", userIds[userIds.Length - 1]);
            return Db.Delete<Sys_Userlogon>(sql);
        }
    }
}
