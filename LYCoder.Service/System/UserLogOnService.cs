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
    public partial class UserLogOnService : BaseService<Sys_Userlogon>
    {
        public static new int Insert(Sys_Userlogon model)
        {
            model.SULLastVisitTime = DateTime.Now;
            model.SULSecretKey = string.Empty;
            model.SULPassword = model.SULPassword.DESEncrypt(model.SULSecretKey).MD5Encrypt();
            model.SULAnswerQuestion = string.Empty;
            model.SULQuestion = string.Empty;
            model.SULLoginCount = 0;
            model.SULIsOnLine = 0;
            return UserLogOnAccess.Insert(model);
        }

        public static Sys_Userlogon GetByAccount(int userId)
        {
            return UserLogOnAccess.GetByAccount(userId);
        }

        public static int UpdateInfo(Sys_Userlogon model)
        {
            var updateColumns = new List<string>() {
                 "SULAllowMultiUserOnline", "SULQuestion", "SULAnswerQuestion",  "SULCheckIPAddress", "SULLanguage", "SULTheme"};
            return UserLogOnAccess.Update(model, updateColumns);
        }

        public static int UpdateLogin(Sys_Userlogon model)
        {
            model.SULIsOnLine = 1;
            model.SULPrevVisitTime = model.SULLastVisitTime;
            model.SULLastVisitTime = DateTime.Now;
            model.SULLoginCount += 1;
            var updateColumns = new List<string>() {
                "SULIsOnLine", "SULPrevVisitTime", "SULLastVisitTime", "SULLoginCount" };
            return UserLogOnAccess.Update(model, updateColumns);
        }

        public static int Delete(params string[] userIds)
        {
            return UserLogOnAccess.Delete(userIds);
        }

        public static bool ModifyPwd(Sys_Userlogon model)
        {
            model.SULChangePwdTime = DateTime.Now;
            var updateColumns = new List<string>() { "SULPassword", "SULChangePwdTime" };
            return UserLogOnAccess.Update(model, updateColumns) > 0 ? true : false;
        }
    }
}
