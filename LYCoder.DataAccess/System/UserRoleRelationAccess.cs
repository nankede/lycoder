using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LYCoder.Entity;

namespace LYCoder.DataAccess
{
    public partial class UserRoleRelationAccess : BaseAccess<Sys_Userrolerelation, Sys_UserrolerelationFields>
    {
        /// <summary>
        /// 设置角色
        /// </summary>
        /// <param name="userId">会员ID</param>
        /// <param name="roleIds">角色列表</param>
        /// <param name="currtUserId">登录用户ID</param>
        public static void SetRole(int userId, List<int> roleIds,int currtUserId)
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
                    SURRCreateUser = currtUserId,
                    SURRCreateTime = DateTime.Now
                });
            });
            //e.旧集合中剩下的用户角色关系从数据库中删除。
            listOldRRs.ForEach((rrObj) =>
            {
                UserRoleRelationAccess.Delete(rrObj);
            });
        }


        public static List<Sys_Userrolerelation> GetList(int userId)
        {
            return Db.Fetch<Sys_Userrolerelation>("where SURRUserId=@0", userId);
        }

        public static int Delete(params string[] userIds)
        {
            Sql sql = Sql.Builder.Append(" WHERE");
            for (int i = 0; i < userIds.Length - 1; i++)
            {
                sql.Append(" SURRUserId=@0 OR", userIds[i]);
            }
            sql.Append(" SURRUserId=@0", userIds[userIds.Length - 1]);
            return Db.Delete<Sys_Userrolerelation>(sql);
        }
    }
}
