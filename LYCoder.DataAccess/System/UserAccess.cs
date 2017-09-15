using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LYCoder.Entity;

namespace LYCoder.DataAccess
{
    public partial class UserAccess : BaseAccess<Sys_User, Sys_UserFields>
    {

        /// <summary>
        /// 创建用户
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static int InsertAll(Sys_User model)
        {
            var userId = 0;
            using (var tran = Db.GetTransaction())
            {
                //新增用户基本信息。
                userId = UserAccess.Insert(model);
                if (userId > 0)
                {
                    //新增用户角色信息。
                    UserRoleRelationAccess.SetRole(userId, model.RoleId, model.SUCreateUser);
                    //新增用户登陆信息。
                    Sys_Userlogon userLogOnEntity = new Sys_Userlogon()
                    {
                        SULUserId = userId,
                        SULLoginName = model.SUAccount,
                        SULPassword = model.Password,
                    };
                    var userLoginId = UserLogOnAccess.Insert(userLogOnEntity);
                }
                tran.Complete();
            }
            return userId;
        }

        public static Sys_User GetByAccount(string account)
        {
            Sql sql = Sql.Builder
                 .Select("u.*,od.SOFullName , oc.SOFullName")
                 .From("Sys_User u")
                 .LeftJoin("Sys_Organize od")
                 .On("u.SUDepartmentId=od.Id")
                  .LeftJoin("Sys_Organize oc")
                 .On("u.SUCompanyId=oc.Id")
                 .Where("u.SUAccount = @0  ", account);
            var user = Db.Query<Sys_User, Sys_Organize, Sys_Organize>(sql);
            return user?.First();
        }

        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="keyWord"></param>
        /// <returns></returns>
        public static Page<Sys_User> GetList(int pageIndex, int pageSize, string keyWord)
        {
            Sql sql = Sql.Builder
                 .Select("u.*,od.SOFullName , oc.SOFullName")
                 .From("Sys_User u")
                 .LeftJoin("Sys_Organize od")
                 .On("u.SUDepartmentId=od.Id")
                  .LeftJoin("Sys_Organize oc")
                 .On("u.SUCompanyId=oc.Id")
                 .Where("u.SUDeleteMark=0 and (u.SUAccount like @0 or u.SURealName like @1 ) ", '%' + keyWord + '%', '%' + keyWord + '%')
                 .OrderBy("u.id desc");

            var sqlStr = Db.LastSQL;
            var list = Db.PageJoin<Sys_User, Sys_Organize, Sys_Organize, Sys_User>((user, dept, comp) =>
            {
                user.DeptName = dept.SOFullName;
                user.CompanyName = comp.SOFullName;
                return user;
            }, pageIndex, pageSize, sql);
            return list;
        }

        /// <summary>
        /// 逻辑删除
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static new int Delete(Sys_User model)
        {
            var updateColumns = new List<Sys_UserFields>() {
                Sys_UserFields.SUIsEnabled,
                Sys_UserFields.SUDeleteMark,
                Sys_UserFields.SUModifyTime,
                Sys_UserFields.SUModifyUser
                };
            return UserAccess.Update(model, updateColumns);
        }
    }
}
