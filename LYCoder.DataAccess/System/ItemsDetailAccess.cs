using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LYCoder.Entity;

namespace LYCoder.DataAccess
{
    public partial class ItemsDetailAccess : BaseAccess<Sys_Itemsdetail, Sys_ItemsdetailFields>
    {
        public static Page<Sys_Itemsdetail> GetList(long pageIndex, long pageSize, string itemId, string keyWord)
        {
            Sql sql = Sql.Builder.Where("SIDDeleteMark=0 and SIDItemId=@0", itemId);
            if (!string.IsNullOrEmpty(keyWord))
            {
                sql.Where("SIDName like @0 or SIDEnCode like @1", '%' + keyWord + '%', '%' + keyWord + '%');
            }
            sql.OrderBy("SIDSortCode");
            return Db.Page<Sys_Itemsdetail>(pageIndex, pageSize, sql);
        }

        public static int Delete(string itemId)
        {
            Sql sql = Sql.Builder.Where("SIDItemId=@0", itemId);
            return Db.Delete<Sys_Itemsdetail>(sql);
        }
    }
}
