using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LYCoder.Entity;

namespace LYCoder.DataAccess
{
    public   partial class PermissionAccess : BaseAccess<Sys_Permission, Sys_PermissionFields>
    {
        public static List<Sys_Permission> GetList()
        {
            Sql sql = Sql.Builder.Where("SPDeleteMark=@0", 0).OrderBy("SPSortCode");
            return Db.Fetch<Sys_Permission>(sql);
        }
        public static Page<Sys_Permission> GetList(int pageIndex, int pageSize, string keyWord)
        {
            Sql sql = Sql.Builder
                .Where("SPDeleteMark=@0 and SPName like @1 or SPEnCode like @2", 0, '%' + keyWord + '%', '%' + keyWord + '%')
                .OrderBy("SPSortCode");
            return Db.Page<Sys_Permission>(pageIndex, pageSize, sql);
        }


        public static int Delete(params string[] primaryKeys)
        {
            Sql sql = Sql.Builder.Append(" WHERE");
            for (int i = 0; i < primaryKeys.Length - 1; i++)
            {
                sql.Append(" Id=@0 OR", primaryKeys[i]);
            }
            sql.Append(" Id=@0", primaryKeys[primaryKeys.Length - 1]);
            return Db.Delete<Sys_Permission>(sql);
        }

        public static long GetChildCount(object parentId)
        {
            Sql sql = Sql.Builder.Select("COUNT(*)").From("Sys_Permission").Where("SPParentId=@0", parentId);
            return Db.ExecuteScalar<long>(sql);
        }
    }
}
