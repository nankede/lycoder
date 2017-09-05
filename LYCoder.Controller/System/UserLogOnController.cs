using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Web.Mvc;
using LYCoder.Web.Controllers;
using LYCoder.Entity;
using LYCoder.Common;
using LYCoder.Service;

namespace LYCoder.Web.Areas.System.Controllers
{
    public class UserLogOnController : BaseController
    {
        [HttpPost,ValidateAntiForgeryToken]
        public ActionResult Form(Sys_Userlogon model)
        {
            if (model.Id == 0 )
            {
                var primaryKey = UserLogOnService.Insert(model);
                return primaryKey > 0 ? Success() : Error();
            }
            else
            {
                var row = UserLogOnService.UpdateInfo(model);
                return row > 0 ? Success() : Error();
            }
        }

    }
}
