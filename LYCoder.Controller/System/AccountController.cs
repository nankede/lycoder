using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LYCoder.Entity;
using LYCoder.Service;
using LYCoder.Common;

namespace LYCoder.Web.Controllers
{
    public class AccountController : BaseController
    {
        /// <summary>
        /// 登陆页面视图。
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        /// <summary>
        /// 提交登陆信息。
        /// </summary>
        /// <param name="username">用户名</param>
        /// <param name="password">密码</param>
        /// <param name="verifycode">验证码</param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Login(string userName, string password, string verifyCode)
        {
            if (userName.IsNullOrEmpty() || password.IsNullOrEmpty() || verifyCode.IsNullOrEmpty())
            {
                return Error("请求失败，缺少必要参数。");
            }
            if (verifyCode.ToLower() != WebHelper.GetSession(Keys.SESSION_KEY_VCODE))
            {
                return Warning("验证码错误，请重新输入。");
            }
            var userEntity = UserService.GetByUserName(userName);
            if (userEntity == null)
            {
                return Warning("该账户不存在，请重新输入。");
            }
            if (userEntity.SUIsEnabled != 1 || userEntity.SUDeleteMark == 1)
            {
                return Warning("该账户已被禁用，请联系管理员。");
            }
            var userLogOnEntity = UserLogOnService.GetByAccount(userEntity.Id);
            string inputPassword = password.DESEncrypt(userLogOnEntity.SULSecretKey).MD5Encrypt();
            if (inputPassword != userLogOnEntity.SULPassword)
            {
                LogHelper.Write(Level.Info, "系统登录", "密码错误", userEntity.Id, userEntity.SURealName);
                return Warning("密码错误，请重新输入。");
            }
            else
            {
                Operator operatorModel = new Operator()
                {
                    UserId = userEntity.Id,
                    Account = userEntity.SUAccount,
                    RealName = userEntity.SURealName,
                    Avatar = userEntity.SUAvatar,
                    CompanyId = userEntity.SUCompanyId,
                    DepartmentId = userEntity.SUDepartmentId,
                    LoginTime = DateTime.Now,
                    LoginCount = userLogOnEntity.SULLoginCount + 1,
                    MessageCount = 0,
                    Token = Guid.NewGuid().ToString().DESEncrypt(),
                };
                OperatorProvider.Instance.Current = operatorModel;
                UserLogOnService.UpdateLogin(userLogOnEntity);
                LogHelper.Write(Level.Info, "系统登录", "登录成功", userEntity.Id, userEntity.SURealName);
                return Success();
            }
        }

        /// <summary>
        /// 获取验证码图片。
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult VerifyCode()
        {
            VerifyCode verify = new VerifyCode();
            WebHelper.SetSession(Keys.SESSION_KEY_VCODE, verify.Text.ToLower());
            return File(verify.Image, "image/jpeg");
        }

        /// <summary>
        /// 安全退出系统。
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Exit()
        {
            if (OperatorProvider.Instance.Current != null)
            {
                OperatorProvider.Instance.Remove();
            }
            return Redirect("/Account/Login");
        }

        /// <summary>
        /// 锁定登陆用户。
        /// </summary>
        /// <returns></returns>
        [HttpPost, LoginChecked]
        public ActionResult Lock()
        {
            if (OperatorProvider.Instance.Current != null)
            {
                OperatorProvider.Instance.Remove();
            }
            return Success();
        }

        /// <summary>
        /// 解锁登陆用户。
        /// </summary>
        /// <param name="username">用户名</param>
        /// <param name="password">密码</param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Unlock(string username, string password)
        {
            var userEntity = UserService.GetByUserName(username);
            var userLogOnEntity = UserLogOnService.GetByAccount(userEntity.Id);
            string inputPassword = password.DESEncrypt(userLogOnEntity.SULSecretKey).MD5Encrypt();
            if (inputPassword != userLogOnEntity.SULPassword)
            {
                return Warning("密码错误，请重新输入。");
            }
            else
            {
                //重新保存用户信息。
                Operator operatorModel = new Operator();
                operatorModel.UserId = userEntity.Id;
                operatorModel.Account = userEntity.SUAccount;
                operatorModel.RealName = userEntity.SURealName;
                operatorModel.Avatar = userEntity.SUAvatar;
                operatorModel.CompanyId = userEntity.SUCompanyId;
                operatorModel.DepartmentId = operatorModel.DepartmentId;
                operatorModel.LoginTime = DateTime.Now;
                operatorModel.Token = Guid.NewGuid().ToString().DESEncrypt();
                operatorModel.LoginCount = userLogOnEntity.SULLoginCount;
                operatorModel.MessageCount = 0;
                OperatorProvider.Instance.Current = operatorModel;
            }
            return Success();
        }

        /// <summary>
        /// 账户管理视图。
        /// </summary>
        /// <returns></returns>
        [HttpGet, LoginChecked]
        public ActionResult InfoCard()
        {
            return View();
        }

        /// <summary>
        /// 更新用户基础资料。
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost, LoginChecked]
        public ActionResult InfoCard(Sys_User model)
        {
            int row = UserService.UpdateBasicInfo(model);
            return row > 0 ? Success() : Error();
        }

        [HttpPost, LoginChecked]
        public ActionResult GetInfoCardForm()
        {
            var current = OperatorProvider.Instance.Current;
            int userId = current.UserId;
            var userEntity = UserService.Get(userId);
            userEntity.MessageCount = 0;
            userEntity.LoginTime = current.LoginTime;
            userEntity.LoginCount = current.LoginCount;
            return Content(userEntity.ToJson());
        }

        /// <summary>
        /// 上传头像。
        /// </summary>
        /// <returns></returns>
        [HttpPost, LoginChecked]
        public ActionResult UploadAvatar()
        {
            var file = Request.Files[0];
            if (file == null) { return Error(); }
            int userId = OperatorProvider.Instance.Current.UserId;

            string virtualPath = Path.Combine("/Uploads/Avatar/", userId + Path.GetExtension(file.FileName));
            string filePath = Request.MapPath(virtualPath);
            if (FileUtil.Exists(filePath))
            {
                FileUtil.Delete(filePath);
            }
            file.SaveAs(filePath);
            return Success("上传成功。", virtualPath);
        }

        /// <summary>
        /// 加载修改密码界面视图。
        /// </summary>
        /// <returns></returns>
        [HttpGet, LoginChecked]
        public ActionResult ModifyPwd()
        {
            return View();
        }

        /// <summary>
        /// 修改密码。
        /// </summary>
        /// <param name="oldPassword">旧密码</param>
        /// <param name="newPassword">新密码</param>
        /// <param name="confirmPassword">确认密码</param>
        /// <returns></returns>
        [HttpPost, LoginChecked]
        public ActionResult ModifyPwd(string oldPassword, string newPassword, string confirmPassword)
        {
            if (oldPassword.IsNullOrEmpty() || newPassword.IsNullOrEmpty() || confirmPassword.IsNullOrEmpty())
            {
                return Error("请求失败，缺少必要参数。");
            }
            if (!newPassword.Equals(confirmPassword))
            {
                return Warning("两次密码输入不一致，请重新确认。");
            }
            int userId = OperatorProvider.Instance.Current.UserId;
            var userLoginEntity = UserLogOnService.GetByAccount(userId);
            if (oldPassword.DESEncrypt(userLoginEntity.SULSecretKey).MD5Encrypt() != userLoginEntity.SULPassword)
            {
                return Warning("旧密码验证失败。");
            }
            userLoginEntity.SULPassword = newPassword.DESEncrypt(userLoginEntity.SULSecretKey).MD5Encrypt();
            bool isSuccess = UserLogOnService.ModifyPwd(userLoginEntity);
            return isSuccess ? Success() : Error();
        }
    }
}