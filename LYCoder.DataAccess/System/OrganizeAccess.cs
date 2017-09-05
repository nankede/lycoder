using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LYCoder.Entity;

namespace LYCoder.DataAccess
{
    public partial class OrganizeAccess : BaseAccess<Sys_Organize, Sys_OrganizeFields>
    {
        public static List<Sys_Organize> GetList(int oId)
        {
            Sql sql = Sql.Builder.Where("SODeleteMark=0").Where("SORootId=@0", oId).OrderBy("SOSortCode");
            return Db.Fetch<Sys_Organize>(sql);
        }

        public static Page<Sys_Organize> GetList(int oId, long pageIndex, long pageSize, string keyWord)
        {
            Sql sql = Sql.Builder
               .Where("SODeleteMark=@0 and SOFullName like @1 or SOEnCode like @2", 0, '%' + keyWord + '%', '%' + keyWord + '%')
               .Where("SORootId=@0", oId)
               .OrderBy("SOSortCode");
            return Db.Page<Sys_Organize>(pageIndex, pageSize, sql);
        }

        public static long GetChildCount(object parentId)
        {
            Sql sql = Sql.Builder.Select("COUNT(*)").From("Sys_Organize").Where("SOParentId=@0", parentId);
            return Db.ExecuteScalar<long>(sql);
        }
    }
}
