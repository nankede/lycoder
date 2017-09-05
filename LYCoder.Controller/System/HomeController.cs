using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LYCoder.Entity;
using LYCoder.Service;
using LYCoder.Common;

namespace LYCoder.Web.Controllers
{
    [LoginChecked]
    public class HomeController : BaseController
    {
        /// <summary>
        /// 后台首页视图。
        /// </summary>
        /// <returns></returns>
        [HttpGet, LoginChecked]
        public ActionResult Index()
        {
            if (OperatorProvider.Instance.Current != null)
            {
                ViewBag.SoftwareName = Configs.GetValue("SoftwareName");
                ViewBag.Account = OperatorProvider.Instance.Current.Account;
                ViewBag.Avatar = OperatorProvider.Instance.Current.Avatar;
                return View();
            }
            else
            {
                return Redirect("/Account/Login");
            }
        }

        /// <summary>
        /// 默认显示视图。
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Default()
        {
            return View();
        }

        /// <summary>
        /// 获取左侧菜单。
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult GetLeftMenu()
        {
            int userId = OperatorProvider.Instance.Current.UserId;

            List<LayNavbar> listNavbar = new List<LayNavbar>();
            var listModules = PermissionService.GetList(userId);
            foreach (var item in listModules.Where(c => c.SPType == ModuleType.Menu && c.SPLayer == 0).ToList())
            {
                LayNavbar navbarEntity = new LayNavbar();
                var listChildNav = listModules.Where(c => c.SPType == ModuleType.Menu && c.SPLayer == 1 && c.SPParentId == item.Id)
                    .Select(c => new LayChildNavbar() { href = c.SPUrl, icon = c.SPIcon, title = c.SPName }).ToList();
                navbarEntity.icon = item.SPIcon;
                navbarEntity.spread = false;
                navbarEntity.title = item.SPName;
                navbarEntity.children = listChildNav;
                listNavbar.Add(navbarEntity);
            }
            return Content(listNavbar.ToJson());
        }

        /// <summary>
        /// 获取登录用户权限。
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult GetPermission()
        {
            var userId = OperatorProvider.Instance.Current.UserId;
            var modules = PermissionService.GetList(userId);
            return Content(modules.ToJson());
        }
    }
}