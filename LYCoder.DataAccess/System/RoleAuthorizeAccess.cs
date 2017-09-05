using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LYCoder.Entity;

namespace LYCoder.DataAccess
{
    public partial class RoleAuthorizeAccess : BaseAccess<Sys_Roleauthorize, Sys_RoleauthorizeFields>
    {

        public static List<Sys_Roleauthorize> GetList()
        {
            return Db.Fetch<Sys_Roleauthorize>("");
        }

        public static List<Sys_Roleauthorize> GetList(object roleId)
        {
            Sql sql = Sql.Builder.Where("SRARoleId=@0", roleId);
            return Db.Fetch<Sys_Roleauthorize>(sql);
        }

        public static int Delete(params string[] moduleIds)
        {
            Sql sql = Sql.Builder.Append(" WHERE");
            for (int i = 0; i < moduleIds.Length - 1; i++)
            {
                sql.Append(" SRAModuleId=@0 OR", moduleIds[i]);
            }
            sql.Append(" SRAModuleId=@0", moduleIds[moduleIds.Length - 1]);
            return Db.Delete<Sys_Roleauthorize>(sql);
        }
    }
}
