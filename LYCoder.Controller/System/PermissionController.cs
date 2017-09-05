using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Text.RegularExpressions;
using LYCoder.Web.Controllers;
using LYCoder.Entity;
using LYCoder.Common;
using LYCoder.Service;

namespace LYCoder.Web.Areas.System.Controllers
{
    [LoginChecked]
    public class PermissionController : BaseController
    {
        [HttpGet, AuthorizeChecked]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost, AuthorizeChecked]
        public ActionResult Index(int pageIndex, int pageSize, string keyWord)
        {
            var pageData = PermissionService.GetList(pageIndex, pageSize, keyWord);
            var result = new LayPadding<Sys_Permission>()
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
        public ActionResult Form(Sys_Permission model)
        {
            if (model.Id == 0)
            {
                var primaryKey = PermissionService.Insert(model);
                return primaryKey > 0 ? Success() : Error();
            }
            else
            {
                int row = PermissionService.Update(model);
                return row > 0 ? Success() : Error();
            }
        }

        [HttpGet, AuthorizeChecked]
        public ActionResult Detail()
        {
            return View();
        }

        [HttpPost, AuthorizeChecked]
        public ActionResult Delete(int primaryKey)
        {
            long count = PermissionService.GetChildCount(primaryKey);
            if (count == 0)
            {
                int row = PermissionService.Delete(primaryKey);
                return row > 0 ? Success() : Error();
            }
            return Error(string.Format("操作失败，请先删除该项的{0}个子级权限。", count));
        }

        [HttpPost]
        public ActionResult GetForm(string primaryKey)
        {
            var entity = PermissionService.Get(primaryKey);
            return Content(entity.ToJson());
        }

        [HttpPost]
        public ActionResult GetParent()
        {
            var data = PermissionService.GetList();
            var treeList = new List<TreeSelect>();
            foreach (Sys_Permission item in data)
            {
                TreeSelect model = new TreeSelect();
                model.id = item.Id;
                model.text = item.SPName;
                model.parentId = item.SPParentId;
                treeList.Add(model);
            }
            return Content(treeList.ToTreeSelectJson());
        }

        [HttpGet]
        public ActionResult Icon()
        {
            return View();
        }

    }

}
