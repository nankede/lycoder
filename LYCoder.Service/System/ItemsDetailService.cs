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
    public partial class ItemsDetailService : BaseService<Sys_Itemsdetail, Sys_ItemsdetailFields>
    {
        public static Page<Sys_Itemsdetail> GetList(long pageIndex, long pageSize, string itemId, string keyWord)
        {
            return ItemsDetailAccess.GetList(pageIndex, pageSize, itemId, keyWord);
        }

        public static int Delete(string itemId)
        {
            return ItemsDetailAccess.Delete(itemId);
        }

        /// <summary>
        /// 逻辑删除
        /// </summary>
        /// <param name="itemId"></param>
        /// <returns></returns>
        public static int Delete(int itemId)
        {
            var model = new Sys_Itemsdetail()
            {
                Id = itemId,
                SIDDeleteMark = 1,
                SIDModifyUser = OperatorProvider.Instance.Current.UserId,
                SIDModifyTime = DateTime.Now,
            };
            var updateColumns = new List<Sys_ItemsdetailFields>() {
            Sys_ItemsdetailFields.SIDDeleteMark,Sys_ItemsdetailFields.SIDModifyUser,Sys_ItemsdetailFields.SIDModifyTime
            };
            return ItemsDetailAccess.Update(model, updateColumns);
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

        public static new int Update(Sys_Itemsdetail model)
        {
            model.SIDModifyUser = OperatorProvider.Instance.Current.UserId;
            model.SIDModifyTime = DateTime.Now;
            var updateColumns = new List<Sys_ItemsdetailFields>() {
            Sys_ItemsdetailFields.SIDItemId,Sys_ItemsdetailFields.SIDEnCode,Sys_ItemsdetailFields.SIDName
            ,Sys_ItemsdetailFields.SIDIsDefault,Sys_ItemsdetailFields.SIDSortCode,Sys_ItemsdetailFields.SIDIsEnabled
            ,Sys_ItemsdetailFields.SIDModifyUser,Sys_ItemsdetailFields.SIDModifyTime
            };
            return ItemsDetailAccess.Update(model, updateColumns);
        }
    }
}
