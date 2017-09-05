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
    public partial class UserRoleRelationService : BaseService<Sys_Userrolerelation, Sys_UserrolerelationFields>
    {
        public static List<Sys_Userrolerelation> GetList(int  userId)
        {
            return UserRoleRelationAccess.GetList(userId);
        }

        public static void SetRole(int  userId, List<int> roleIds)
        {
            //a.用户需要重新设置的角色ID集合。
            var listNewRoleIds = roleIds.ToList();
            //b.用户原有的角色信息。
            var listOldRRs = UserRoleRelationAccess.GetList(userId);
            //c.删除用户新设置和原有用户角色关系集合中相同的记录。
            for (int i = listOldRRs.Count - 1; i >= 0; i--)
            {
                if (listNewRoleIds.Contains(listOldRRs[i].SURRRoleId))
                {
                    listNewRoleIds.Remove(listOldRRs[i].SURRRoleId);
                    listOldRRs.Remove(listOldRRs[i]);
                }
            }
            //d.新集合中剩下的用户角色关系新增到数据库。
            listNewRoleIds.ForEach((roleId) =>
            {
                UserRoleRelationAccess.Insert(new Sys_Userrolerelation()
                {
                    SURRUserId = userId,
                    SURRRoleId = roleId,
                    SURRCreateUser = OperatorProvider.Instance.Current.UserId,
                    SURRCreateTime = DateTime.Now
                });
            });
            //e.旧集合中剩下的用户角色关系从数据库中删除。
            listOldRRs.ForEach((rrObj) =>
            {
                Delete(rrObj.Id);
            });
        }

        /// <summary>
        /// 逻辑删除
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public static int Delete(int Id)
        {
            var model = new Sys_Userrolerelation()
            {
                Id = Id,
                SURRDeleteMark = 1,
                SURRModifyUser = OperatorProvider.Instance.Current.UserId,
                SURRModifyTime = DateTime.Now,
            };
            var updateColumns = new List<Sys_UserrolerelationFields>() {
            Sys_UserrolerelationFields.SURRDeleteMark,Sys_UserrolerelationFields.SURRModifyUser,Sys_UserrolerelationFields.SURRModifyTime
            };
            return UserRoleRelationAccess.Update(model, updateColumns);
        }
    }
}
