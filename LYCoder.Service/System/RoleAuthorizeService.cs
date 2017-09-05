using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using LYCoder.Common;
using LYCoder.Entity;
using LYCoder.DataAccess;

namespace LYCoder.Service
{
    public partial class RoleAuthorizeService : BaseService<Sys_Roleauthorize>
    {
        public static List<Sys_Roleauthorize> GetList(object roleId)
        {
            return RoleAuthorizeAccess.GetList(roleId);
        }

        public static void Authorize(int roleId, params string[] perIds)
        {
            //a.角色需要重新设置的权限ID集合。
            var listNewPerIds = perIds.ToList();
            //b.角色原有的授权信息。
            var listOldPers = RoleAuthorizeAccess.GetList(roleId);
            //c.删除角色新设置和原有授权信息集合中相同的记录。
            for (int i = listOldPers.Count - 1; i >= 0; i--)
            {
                if (listNewPerIds.Contains(listOldPers[i].SRAModuleId.ToString()))
                {
                    listNewPerIds.Remove(listOldPers[i].SRAModuleId.ToString());
                    listOldPers.Remove(listOldPers[i]);
                }
            }
            //d.新集合中剩下的授权信息新增到数据库。
            listNewPerIds.ForEach((perId) =>
            {
                RoleAuthorizeAccess.Insert(new Sys_Roleauthorize()
                {
                    SRARoleId = roleId,
                    SRAModuleId = ConvertHelper.ToInt32(perId, 0),
                    SRACreateUser = OperatorProvider.Instance.Current.UserId,
                    SRACreateTime = DateTime.Now
                });
            });
            //e.旧集合中剩下的授权信息从数据库中删除。
            listOldPers.ForEach((perObj) =>
            {
                RoleAuthorizeAccess.Delete(perObj);
            });
        }
    }
}
