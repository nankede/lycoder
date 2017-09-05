using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using LYCoder.Common;
using LYCoder.Entity;
using LYCoder.Service;

namespace LYCoder.Web.Controllers
{
    /// <summary>
    /// 控制器基类。
    /// </summary>
    public class BaseController : Controller
    {
        #region 快捷方法
        protected ActionResult Success(string Message = "恭喜您，操作成功。", object Data = null)
        {
            return Content(new AjaxResult(ResultType.Success, Message, Data).ToJson());
        }
        protected ActionResult Error(string Message = "对不起，操作失败。", object Data = null)
        {
            return Content(new AjaxResult(ResultType.Error, Message, Data).ToJson());
        }
        protected ActionResult Warning(string Message, object Data = null)
        {
            return Content(new AjaxResult(ResultType.Warning, Message, Data).ToJson());
        }
        protected ActionResult Info(string Message, object Data = null)
        {
            return Content(new AjaxResult(ResultType.Info, Message, Data).ToJson());
        }
        #endregion
    }

    /// <summary>
    /// 表示一个特性，该特性用于标识用户是否有访问权限。
    /// </summary>
    public class AuthorizeCheckedAttribute : AuthorizeAttribute
    {
        /// <summary>
        /// 是否忽略权限检查。
        /// </summary>
        public bool Ignore { get; set; }

        public AuthorizeCheckedAttribute(bool ignore = false)
        {
            this.Ignore = ignore;
        }

        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            if (Ignore)
            {
                return;
            };
            var userId = OperatorProvider.Instance.Current.UserId;
            var action = HttpContext.Current.Request.ServerVariables["SCRIPT_NAME"].ToString();
            var title = string.Empty;
            bool hasPermission = PermissionService.ActionValidate(userId, action, out title);
            if (!hasPermission)
            {
                StringBuilder script = new StringBuilder();
                script.Append("<script>alert('对不起，您没有权限访问当前页面。');</script>");
                filterContext.Result = new ContentResult() { Content = script.ToString() };
            }
        }


    }

    /// <summary>
    /// 表示一个特性，该特性用于标识用户是否需要登陆。
    /// </summary>
    public class LoginCheckedAttribute : ActionFilterAttribute
    {

        public bool Ignore { get; set; }
        public LoginCheckedAttribute(bool ignore = true)
        {
            Ignore = ignore;
        }

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (!Ignore)
            {
                return;
            }
            if (OperatorProvider.Instance.Current == null)
            {
                filterContext.HttpContext.Response.Write("<script>top.location.href = '/Account/Login'</script>");
            }
        }
    }

    /// <summary>
    /// 表示一个特性，该特性用于捕获程序运行异常。
    /// </summary>
    public class ErrorCheckedAttribute : HandleErrorAttribute
    {
        public override void OnException(ExceptionContext filterContext)
        {
            //filterContext.HttpContext.Response.StatusCode = 500;
            filterContext.ExceptionHandled = true;
            Operator onlineUser = OperatorProvider.Instance.Current;
            LogHelper.Write(Level.Error, filterContext.Exception.Message, filterContext.Exception.StackTrace, onlineUser == null ? 0 : onlineUser.UserId, onlineUser == null ? "未知用户" : onlineUser.RealName);
            if (onlineUser == null)
            {
                filterContext.Result = new RedirectResult("/Account/Login");
            }
            else
            {
                filterContext.Result = new ContentResult() { Content = new AjaxResult(ResultType.Error, "操作失败，请稍后再试！", null).ToJson() };
            }
        }
    }
}
