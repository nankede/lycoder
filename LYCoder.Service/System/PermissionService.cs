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
    public partial class PermissionService : BaseService<Sys_Permission, Sys_PermissionFields>
    {
        public static new int Insert(Sys_Permission model)
        {
            if (model.SPParentId > 0)
            {
                var parent = PermissionAccess.Get(model.SPParentId);
                model.SPLayer = parent == null ? 0 : (parent.SPLayer + 1);
            }
            model.SPIsEnabled = 1;
            model.SPDeleteMark = 0;
            model.SPCreateUser = OperatorProvider.Instance.Current.UserId;
            model.SPCreateTime = DateTime.Now;
            model.SPModifyUser = model.SPCreateUser;
            model.SPModifyTime = model.SPCreateTime;
            return PermissionAccess.Insert(model);
        }

        /// <summary>
        /// 逻辑删除
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public static int Delete(int Id)
        {
            var model = new Sys_Permission()
            {
                Id = Id,
                SPDeleteMark = 1,
                SPModifyUser = OperatorProvider.Instance.Current.UserId,
                SPModifyTime = DateTime.Now,
            };
            var updateColumns = new List<Sys_PermissionFields>() {
            Sys_PermissionFields.SPDeleteMark,Sys_PermissionFields.SPModifyUser,Sys_PermissionFields.SPModifyTime
            };
            return PermissionAccess.Update(model, updateColumns);
        }

        public static new int Update(Sys_Permission model)
        {
            if (model.SPParentId > 0)
            {
                var parent = PermissionAccess.Get(model.SPParentId);
                model.SPLayer = parent == null ? 0 : (parent.SPLayer + 1);
            }
            model.SPModifyUser = OperatorProvider.Instance.Current.UserId;
            model.SPModifyTime = DateTime.Now;
            var updateColumns = new List<Sys_PermissionFields>() {
                Sys_PermissionFields.SPParentId,Sys_PermissionFields.SPLayer,Sys_PermissionFields.SPEnCode
                ,Sys_PermissionFields.SPName,Sys_PermissionFields.SPJsEvent,Sys_PermissionFields.SPIcon
                ,Sys_PermissionFields.SPUrl,Sys_PermissionFields.SPRemark,Sys_PermissionFields.SPType
                ,Sys_PermissionFields.SPSortCode,Sys_PermissionFields.SPIsPublic,Sys_PermissionFields.SPIsEnabled
                ,Sys_PermissionFields.SPIsEdit,Sys_PermissionFields.SPModifyUser,Sys_PermissionFields.SPModifyTime };
            return PermissionAccess.Update(model, updateColumns);
        }

        public static List<Sys_Permission> GetList()
        {
            return PermissionAccess.GetList();
        }

        public static List<Sys_Permission> GetList(int userId)
        {
            //a.根据用户ID查询角色ID集合 （一对多关系）
            var listRoleIds = UserRoleRelationAccess.GetList(userId).Select(c => c.SURRRoleId).ToList();
            //b.根据角色ID查询权限ID集合 （多对多关系）
            var listModuleIds = RoleAuthorizeAccess.GetList().Where(c => listRoleIds.Contains(c.SRARoleId)).Select(c => c.SRAModuleId).ToList();
            //c.根据权限ID集合查询所有权限实体。
            return PermissionAccess.GetList().Where(c => listModuleIds.Contains(c.Id) && c.SPIsEnabled == 1).ToList();
        }

        public static Page<Sys_Permission> GetList(int pageIndex, int pageSize, string keyWord)
        {
            return PermissionAccess.GetList(pageIndex, pageSize, keyWord);
        }

        public static bool ActionValidate(int userId, string action, out string title)
        {
            title = string.Empty;
            var authorizeModules = new List<Sys_Permission>();
            authorizeModules = WebHelper.GetCache<List<Sys_Permission>>("authorize_modules_" + userId);
            if (authorizeModules == null)
            {
                authorizeModules = GetList(userId);
                //设置缓存有效时间20分钟。
                WebHelper.SetCache<List<Sys_Permission>>("authorize_modules_" + userId, authorizeModules, DateTime.Now.AddMinutes(20));
            }
            foreach (var item in authorizeModules)
            {
                if (!string.IsNullOrEmpty(item.SPUrl))
                {
                    string[] url = item.SPUrl.Split('?');
                    if (url[0].ToLower() == action.ToLower())
                    {
                        title = item.SPName;
                        return true;
                    }
                }
            }
            return false;
        }

        public static int Delete(params string[] primaryKeys)
        {
            //删除权限与角色的对应关系。
            RoleAuthorizeAccess.Delete(primaryKeys);
            return PermissionAccess.Delete(primaryKeys);
        }

        public static long GetChildCount(object parentId)
        {
            return PermissionAccess.GetChildCount(parentId);
        }
    }
}
