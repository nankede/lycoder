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
    public class RoleAuthorizeController : BaseController
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(string roleId)
        {
            var listPerIds = RoleAuthorizeService.GetList(roleId).Select(c => c.SRAModuleId).ToList();
            var listAllPers = PermissionService.GetList();
            List<ZTreeNode> result = new List<ZTreeNode>();
            foreach (var item in listAllPers)
            {
                ZTreeNode model = new ZTreeNode();
                model.@checked = listPerIds.Contains(item.Id) ? model.@checked = true : model.@checked = false;
                model.id = item.Id;
                model.pId = item.SPParentId;
                model.name = item.SPName;
                model.open = true;
                result.Add(model);
            }
            return Content(result.ToJson());
        }

        [HttpPost]
        public ActionResult Form(int roleId, string perIds)
        {
            RoleAuthorizeService.Authorize(roleId, perIds.ToStrArray());
            return Success("授权成功");
        }

    }
}
