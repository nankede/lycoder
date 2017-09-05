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
    public class ItemsDetailController : BaseController
    {
        [HttpGet, AuthorizeChecked]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost, AuthorizeChecked]
        public ActionResult Index(int pageIndex, int pageSize, string itemId, string keyWord)
        {
            var pageData = ItemsDetailService.GetList(pageIndex, pageSize, itemId, keyWord);
            var result = new LayPadding<Sys_Itemsdetail>()
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
        public ActionResult Form(Sys_Itemsdetail model)
        {
            if (model.Id > 0)
            {
                var primaryKey = ItemsDetailService.Insert(model);
                return primaryKey > 0 ? Success() : Error();
            }
            else
            {
                int row = ItemsDetailService.Update(model);
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
            int row = ItemsDetailService.Delete(primaryKey);
            return row > 0 ? Success() : Error();
        }

        [HttpPost]
        public ActionResult GetForm(string primaryKey)
        {
            var entity = ItemsDetailService.Get(primaryKey);
            return Content(entity.ToJson());
        }

    }
}
