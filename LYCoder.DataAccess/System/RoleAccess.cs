using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LYCoder.Entity;

namespace LYCoder.DataAccess
{
    public partial class RoleAccess : BaseAccess<Sys_Role, Sys_RoleFields>
    {
        public static Page<Sys_Role> GetList(long pageIndex, long pageSize, string keyWord)
        {
            Sql sql = Sql.Builder
               .Select("r.*, o.SOFullName")
               .From("Sys_Role r")
               .LeftJoin("Sys_Organize o")
               .On("r.SROrganizeId=o.Id")
               .Where("r.SRDeleteMark=0 and r.SRName like @0 or r.SREnCode like @1", '%' + keyWord + '%', '%' + keyWord + '%')
               .OrderBy("r.SRSortCode");

            var list = Db.PageJoin<Sys_Role, Sys_Organize, Sys_Role>((role, dept) =>
            {
                role.DeptName = dept.SOFullName;
                return role;
            }, pageIndex, pageSize, sql);

            return list;
        }

        public static int Delete(params string[] primaryKeys)
        {
            Sql sql = Sql.Builder.Append(" WHERE");
            for (int i = 0; i < primaryKeys.Length - 1; i++)
            {
                sql.Append(" Id=@0 OR", primaryKeys[i]);
            }
            sql.Append(" Id=@0", primaryKeys[primaryKeys.Length - 1]);
            return Db.Delete<Sys_Role>(sql);
        }

        public static List<Sys_Role> GetList()
        {
            Sql sql = Sql.Builder.Where("SRDeleteMark=@0", 0).OrderBy("SRSortCode");
            return Db.Fetch<Sys_Role>(sql);
        }
    }
}
