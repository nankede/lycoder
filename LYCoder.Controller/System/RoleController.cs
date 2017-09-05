using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LYCoder.Web.Controllers;
using LYCoder.Entity;
using LYCoder.Common;
using LYCoder.Service;

namespace LYCoder.Web.Areas.System.Controllers
{
    [LoginChecked]
    public class RoleController : BaseController
    {
        [HttpGet, AuthorizeChecked]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost, AuthorizeChecked]
        public ActionResult Index(int pageIndex, int pageSize, string keyWord)
        {
            var pageData = RoleService.GetList(pageIndex, pageSize, keyWord);
            var result = new LayPadding<Sys_Role>()
            {
                Result = true,
                Msg = "success",
                List = pageData.Items,
                Count = pageData.TotalItems
            };
            return Content(result.ToJson());
        }

        [HttpGet, AuthorizeChecked]
        public ActionResult Form()
        {
            return View();
        }

        [HttpPost, AuthorizeChecked, ValidateAntiForgeryToken]
        public ActionResult Form(Sys_Role model)
        {
            if (model.Id == 0 )
            {
                var primaryKey = RoleService.Insert(model);
                return primaryKey > 0 ? Success() : Error();
            }
            else
            {
                int row = RoleService.Update(model);
                return row > 0 ? Success() : Error();
            }
        }

        [HttpGet, AuthorizeChecked]
        public ActionResult Detail()
        {
            return View();
        }

        [HttpPost]
        public ActionResult GetForm(string primaryKey)
        {
            var entity = RoleService.Get(primaryKey);
            return Content(entity.ToJson());
        }

        [HttpPost, AuthorizeChecked]
        public ActionResult Delete(int primaryKey)
        {
            int row = RoleService.Delete(primaryKey);
            return row > 0 ? Success() : Error();
        }

        [HttpPost]
        public ActionResult GetListTreeSelect()
        {
            List<Sys_Role> listRole = RoleService.GetList();
            var listTree = new List<TreeSelect>();
            foreach (var item in listRole)
            {
                TreeSelect model = new TreeSelect();
                model.id = item.Id;
                model.text = item.SRName;
                listTree.Add(model);
            }
            return Content(listTree.ToJson());
        }
    }


}
