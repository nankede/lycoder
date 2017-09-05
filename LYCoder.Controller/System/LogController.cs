﻿using System;
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
    public class LogController : BaseController
    {

        [HttpGet, AuthorizeChecked]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost, AuthorizeChecked]
        public ActionResult Index(long pageIndex, long pageSize, string queryDate, string keyWord, string level)
        {
            DateTime limitDate = DateTime.Now.StartDateTime();

            if (!queryDate.IsNullOrEmpty())
            {
                switch (queryDate)
                {
                    case "7":
                        limitDate = DateTime.Now.AddDays(-7).StartDateTime();
                        break;
                    case "30":
                        limitDate = DateTime.Now.AddMonths(-1).StartDateTime();
                        break;
                    case "90":
                        limitDate = DateTime.Now.AddMonths(-3).StartDateTime();
                        break;
                    default:
                        limitDate = DateTime.Now.StartDateTime();
                        break;
                }
            }

            var pageData = LogService.GetList(pageIndex, pageSize, limitDate, keyWord, level);
            var result = new LayPadding<Sys_Log>()
            {
                Result = true,
                Msg = "success",
                List = pageData.Items,
                Count = pageData.TotalItems
            };
            return Content(result.ToJson());
        }

        [HttpGet, AuthorizeChecked]
        public ActionResult Delete()
        {
            return View();
        }

        [HttpPost, AuthorizeChecked, ValidateAntiForgeryToken]
        public ActionResult Delete(string keepType)
        {
            DateTime keeyDate = DateTime.Now.StartDateTime();

            if (!keepType.IsNullOrEmpty())
            {
                switch (keepType)
                {
                    case "7":
                        keeyDate = DateTime.Now.AddDays(-7).StartDateTime();
                        break;
                    case "30":
                        keeyDate = DateTime.Now.AddMonths(-1).StartDateTime();
                        break;
                    case "90":
                        keeyDate = DateTime.Now.AddMonths(-3).StartDateTime();
                        break;
                    default:
                        keeyDate = DateTime.Now;
                        break;
                }
                LogService.Delete(keeyDate);
                return Success();
            }
            return Error();
        }

    }
}
