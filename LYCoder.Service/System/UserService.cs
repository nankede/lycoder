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
    public partial class UserService : BaseService<Sys_User>
    {
        /// <summary>
        /// 新增用户，含角色、登录
        /// </summary>
        /// <param name="model"></param>
        /// <returns>会员ID</returns>
        public static int InsertAll(Sys_User model)
        {
            var currt = OperatorProvider.Instance.Current;
            model.SUDeleteMark = 0;
            model.SUCreateUser = currt.UserId;
            model.SUCompanyId = currt.CompanyId;
            model.SUCreateTime = DateTime.Now;
            model.SUModifyUser = model.SUCreateUser;
            model.SUModifyTime = model.SUCreateTime;
            model.SUAvatar = "/content/framework/images/avatar.png";
            return UserAccess.InsertAll(model);
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static new int Update(Sys_User model)
        {
            model.SUModifyUser = OperatorProvider.Instance.Current.UserId;
            model.SUModifyTime = DateTime.Now;
            var updateColumns = new List<string>() {
                "SURealName", "SUNickName", "SUGender", "SUBirthday", "SUMobilePhone",
                "SUEmail", "SUSignature", "SUAddress", "SUDepartmentId" ,
                "SUIsEnabled", "SUModifyUser" , "SUModifyTime"};
            return UserAccess.Update(model, updateColumns);
        }

        /// <summary>
        /// 根据账户查用户实体
        /// </summary>
        /// <param name="account"></param>
        /// <returns></returns>
        public static Sys_User GetByUserName(string account)
        {
            return UserAccess.GetByAccount(account);
        }

        public static Page<Sys_User> GetList(int pageIndex, int pageSize, string keyWord)
        {
            return UserAccess.GetList(pageIndex, pageSize, keyWord);
        }
        /// <summary>
        /// 逻辑删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static int Delete(int id)
        {
            var currt = OperatorProvider.Instance.Current;
            var model = new Sys_User
            {
                Id = id,
                SUModifyTime = DateTime.Now,
                SUModifyUser = currt.UserId,
                SUIsEnabled = 0,
                SUDeleteMark = 1
            };
            return UserAccess.Delete(model);
        }

        /// <summary>
        /// 更新用户信息
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static int UpdateBasicInfo(Sys_User model)
        {
            model.SUModifyUser = OperatorProvider.Instance.Current.UserId;
            model.SUModifyTime = DateTime.Now;
            var updateColumns = new List<Sys_UserFields>() {
                Sys_UserFields.SURealName,Sys_UserFields.SUNickName,Sys_UserFields.SUGender,
                Sys_UserFields.SUBirthday,  Sys_UserFields.SUMobilePhone,  Sys_UserFields.SUAvatar,
                Sys_UserFields.SUEmail,  Sys_UserFields.SUSignature,  Sys_UserFields.SUAddress,
                Sys_UserFields.SUModifyUser,  Sys_UserFields.SUModifyTime
            };
            return UserAccess.Update(model, updateColumns);
        }
    }
}
