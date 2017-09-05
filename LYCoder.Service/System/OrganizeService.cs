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
    public partial class OrganizeService : BaseService<Sys_Organize, Sys_OrganizeFields>
    {
        public static List<Sys_Organize> GetList()
        {
            var oId = OperatorProvider.Instance.Current.CompanyId;
            return OrganizeAccess.GetList(oId);
        }

        public static Page<Sys_Organize> GetList(long pageIndex, long pageSize, string keyWord)
        {
            var oId = OperatorProvider.Instance.Current.CompanyId;
            return OrganizeAccess.GetList(oId, pageIndex, pageSize, keyWord);
        }

        public static new int Insert(Sys_Organize model)
        {
            var oId = OperatorProvider.Instance.Current.CompanyId;
            if (model.SOParentId > 0)
            {
                var parent = OrganizeAccess.Get(model.SOParentId);
                model.SOLayer = parent == null ? 0 : (parent.SOLayer + 1);
            }
            model.SORootId = oId;
            model.SODeleteMark = 0;
            model.SOCreateUser = OperatorProvider.Instance.Current.UserId;
            model.SOCreateTime = DateTime.Now;
            model.SOModifyUser = model.SOCreateUser;
            model.SOModifyTime = model.SOCreateTime;
            return OrganizeAccess.Insert(model);
        }

        /// <summary>
        /// 逻辑删除
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public static int Delete(int Id)
        {
            var model = new Sys_Organize()
            {
                Id = Id,
                SODeleteMark = 1,
                SOModifyUser = OperatorProvider.Instance.Current.UserId,
                SOModifyTime = DateTime.Now,
            };
            var updateColumns = new List<Sys_OrganizeFields>() {
            Sys_OrganizeFields.SODeleteMark,Sys_OrganizeFields.SOModifyUser,Sys_OrganizeFields.SOModifyTime
            };
            return OrganizeAccess.Update(model, updateColumns);
        }


        public static new int Update(Sys_Organize model)
        {
            model.SOModifyUser = OperatorProvider.Instance.Current.UserId;
            model.SOModifyTime = DateTime.Now;
            var updateColumns = new List<Sys_OrganizeFields>() {
                Sys_OrganizeFields.SOParentId,Sys_OrganizeFields.SOLayer,Sys_OrganizeFields.SOEnCode
                ,Sys_OrganizeFields.SOFullName,Sys_OrganizeFields.SOType,Sys_OrganizeFields.SOManagerId
                ,Sys_OrganizeFields.SOTelePhone,Sys_OrganizeFields.SOWeChat,Sys_OrganizeFields.SOFax
                ,Sys_OrganizeFields.SOEmail,Sys_OrganizeFields.SOAddress,Sys_OrganizeFields.SOSortCode
                ,Sys_OrganizeFields.SOIsEnabled,Sys_OrganizeFields.SORemark,Sys_OrganizeFields.SOModifyUser
                ,Sys_OrganizeFields.SOModifyTime};
            return OrganizeAccess.Update(model, updateColumns);
        }

        public static long GetChildCount(object parentId)
        {
            return OrganizeAccess.GetChildCount(parentId);
        }
    }
}
