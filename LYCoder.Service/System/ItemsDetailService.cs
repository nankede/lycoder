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
    public partial class ItemsDetailService : BaseService<Sys_Itemsdetail>
    {
        public static Page<Sys_Itemsdetail> GetList(long pageIndex, long pageSize, string itemId, string keyWord)
        {
            return ItemsDetailAccess.GetList(pageIndex, pageSize, itemId, keyWord);
        }

        public static int Delete(string itemId)
        {
            return ItemsDetailAccess.Delete(itemId);
        }

        public static new int Insert(Sys_Itemsdetail model)
        {
            model.SIDDeleteMark = 0;
            model.SIDCreateUser = OperatorProvider.Instance.Current.UserId;
            model.SIDCreateTime = DateTime.Now;
            model.SIDModifyUser = model.SIDCreateUser;
            model.SIDModifyTime = model.SIDCreateTime;
            return ItemsDetailAccess.Insert(model);
        }

        public  static new int Update(Sys_Itemsdetail model)
        {
            model.SIDModifyUser = OperatorProvider.Instance.Current.UserId;
            model.SIDModifyTime = DateTime.Now;
            var updateColumns = new List<string>() {
                "SIDItemId", "SIDEnCode", "SIDName", "SIDIsDefault", "SIDSortCode",
                "SIDIsEnabled",  "SIDModifyUser","SIDModifyTime" };
            return ItemsDetailAccess.Update(model, updateColumns);
        }
    }
}
