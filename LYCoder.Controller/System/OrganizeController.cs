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
    public class OrganizeController : BaseController
    {

        [HttpGet, AuthorizeChecked]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost, AuthorizeChecked]
        public ActionResult Index(int pageIndex, int pageSize, string keyWord)
        {
            var pageData = OrganizeService.GetList(pageIndex, pageSize, keyWord);
            var result = new LayPadding<Sys_Organize>()
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
        public ActionResult Form(Sys_Organize model)
        {
            if (model.Id == 0)
            {
                var primaryKey = OrganizeService.Insert(model);
                return primaryKey > 0 ? Success() : Error();
            }
            else
            {
                int row = OrganizeService.Update(model);
                return row > 0 ? Success() : Error();
            }
        }

        [HttpPost]
        public ActionResult GetForm(string primaryKey)
        {
            var entity = OrganizeService.Get(primaryKey);
            return Content(entity.ToJson());
        }

        [HttpPost, AuthorizeChecked]
        public ActionResult Delete(int primaryKey)
        {
            long count = OrganizeService.GetChildCount(primaryKey);
            if (count == 0)
            {
                int row = OrganizeService.Delete(primaryKey);
                return row > 0 ? Success() : Error();
            }
            return Error(string.Format("操作失败，请先删除该项的{0}个子级机构。", count));
        }

        [HttpGet, AuthorizeChecked]
        public ActionResult Detail()
        {
            return View();
        }

        [HttpPost]
        public ActionResult GetListTreeSelect()
        {
            var currt = OperatorProvider.Instance.Current;
            var data = OrganizeService.GetList();
            var treeList = new List<TreeSelect>();
            treeList.Add(new TreeSelect()
            {
                id = currt.CompanyId,
                text = currt.CompanyName,
                parentId = -1
            });
            foreach (Sys_Organize item in data)
            {
                TreeSelect model = new TreeSelect();
                model.id = item.Id;
                model.text = item.SOFullName;
                model.parentId = item.SOParentId;
                treeList.Add(model);
            }
            return Content(treeList.ToTreeSelectJson());
        }
    }
}
