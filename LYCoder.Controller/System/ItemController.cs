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
    public class ItemController : BaseController
    {
        [HttpGet, AuthorizeChecked]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost, AuthorizeChecked]
        public ActionResult Index(long pageIndex, long pageSize, string keyWord)
        {
            var pageData = ItemService.GetList(pageIndex, pageSize, keyWord);
            var result = new LayPadding<Sys_Item>()
            {
                Result = true,
                Msg = "success",
                List = pageData.Items,
                Count = pageData.TotalItems
            };
            return Content(result.ToJson());
        }

        [HttpGet]
        public ActionResult Form()
        {
            return View();
        }

        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult Form(Sys_Item model)
        {
            if (model.Id == 0)
            {
                var primaryKey = ItemService.Insert(model);
                return primaryKey > 0 ? Success() : Error();
            }
            else
            {
                int row = ItemService.Update(model);
                return row > 0 ? Success() : Error();
            }
        }

        [HttpPost]
        public ActionResult GetForm(string primaryKey)
        {
            var entity = ItemService.Get(primaryKey);
            return Content(entity.ToJson());
        }

        [HttpPost]
        public ActionResult Delete(string primaryKey)
        {
            long count = ItemService.GetChildCount(primaryKey);
            if (count == 0)
            {
                //删除字典。
                int row = ItemService.Delete(primaryKey);
                //删除字典选项。
                ItemsDetailService.Delete(primaryKey);
                return row > 0 ? Success() : Error();
            }
            return Warning(string.Format("操作失败，请先删除该项的{0}个子级字典。", count));
        }

        [HttpGet]
        public ActionResult Detail()
        {
            return View();
        }

        [HttpPost]
        public ActionResult GetListTree()
        {
            var listAllItems = ItemService.GetList();
            List<ZTreeNode> result = new List<ZTreeNode>();
            foreach (var item in listAllItems)
            {
                ZTreeNode model = new ZTreeNode()
                {
                    id = item.Id,
                    pId = item.SIParentId,
                    name = item.SIName,
                    open = true,
                };
                result.Add(model);
            }
            return Content(result.ToJson());
        }

        [HttpPost]
        public ActionResult GetListSelectTree()
        {
            var data = ItemService.GetList();
            var treeList = new List<TreeSelect>();
            foreach (var item in data)
            {
                TreeSelect model = new TreeSelect()
                {
                    id = item.Id,
                    text = item.SIName,
                    parentId = item.SIParentId
                };
                treeList.Add(model);
            }
            return Content(treeList.ToTreeSelectJson());
        }
    }
}
