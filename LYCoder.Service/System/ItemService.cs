using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LYCoder.Entity;
using LYCoder.Common;
using LYCoder.DataAccess;

namespace LYCoder.Service
{
    public partial class ItemService : BaseService<Sys_Item>
    {
        public static List<Sys_Item> GetList()
        {
            return ItemAccess.GetList();
        }

        public static Page<Sys_Item> GetList(long pageIndex, long pageSize, string keyWord)
        {
            return ItemAccess.GetList(pageIndex, pageSize, keyWord);
        }

        public static long GetChildCount(object parentId)
        {
            return ItemAccess.GetChildCount(parentId);
        }

        public static new int Insert(Sys_Item model)
        {
            if (model.SIParentId > 0)
            {
                var parent = ItemAccess.Get(model.SIParentId);
                model.SILayer = parent == null ? 0 : (parent.SILayer + 1);
            }
            model.SIIsEnabled = 1;
            model.SIDeleteMark = 0;
            model.SICreateUser = OperatorProvider.Instance.Current.UserId;
            model.SICreateTime = DateTime.Now;
            model.SIModifyUser = model.SICreateUser;
            model.SIModifyTime = model.SICreateTime;
            return ItemAccess.Insert(model);
        }

        public static new int Update(Sys_Item model)
        {
            if (model.SIParentId > 0)
            {
                var parent = ItemAccess.Get(model.SIParentId);
                model.SILayer = parent == null ? 0 : (parent.SILayer + 1);
            }
            model.SIModifyUser = OperatorProvider.Instance.Current.UserId;
            model.SIModifyTime = DateTime.Now;
            var updateColumns = new List<string>() {
                "SIParentId", "SILayer", "SIEnCode", "SIName", "SISortCode",
                "SIIsEnabled",  "SIRemark","SIModifyUser", "SIModifyTime" };
            return ItemAccess.Update(model, updateColumns);
        }
    }
}
