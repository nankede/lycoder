using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LYCoder.Entity;

namespace LYCoder.DataAccess
{
    public partial class ItemAccess : BaseAccess<Sys_Item, Sys_ItemFields>
    {
        public static List<Sys_Item> GetList()
        {
            Sql sql = Sql.Builder.Where("SIDeleteMark=@0", 0);
            return Db.Fetch<Sys_Item>(sql);
        }

        public static Page<Sys_Item> GetList(long pageIndex, long pageSize, string keyWord)
        {
            Sql sql = Sql.Builder.Where("SIDeleteMark=@0", 0);
            if (!string.IsNullOrEmpty(keyWord))
            {
                sql.Where("SIName like @0 or SIEnCode like @1", '%' + keyWord + '%', '%' + keyWord + '%');
            }
            sql.OrderBy("SISortCode");
            return Db.Page<Sys_Item>(pageIndex, pageSize, sql);
        }

        public static long GetChildCount(object parentId)
        {
            Sql sql = Sql.Builder.Select("COUNT(*)").From("Sys_Item").Where("SIParentId=@0", parentId);
            return Db.ExecuteScalar<long>(sql);
        }
    }
}
