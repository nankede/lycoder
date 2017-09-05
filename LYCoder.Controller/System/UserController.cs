using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Web;
using System.Web.Mvc;
using LYCoder.Web.Controllers;
using LYCoder.Entity;
using LYCoder.Common;
using LYCoder.Service;

namespace LYCoder.Web.Areas.System.Controllers
{
    [LoginChecked]
    public class UserController : BaseController
    {
        [HttpGet, AuthorizeChecked]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost, AuthorizeChecked]
        public ActionResult Index(int pageIndex, int pageSize, string keyWord)
        {
            var pageData = UserService.GetList(pageIndex, pageSize, keyWord);
            var result = new LayPadding<Sys_User>()
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
        public ActionResult Form(Sys_User model, string password, string roleIds)
        {
            var roleList = ConvertHelper.IntList(roleIds);

            if (model.Id == 0)
            {
                model.RoleId = roleList;
                model.Password = password;
                var userId = UserService.InsertAll(model);
                return userId > 0 ? Success() : Error();
            }
            else
            {
                //更新用户基本信息。
                int row = UserService.Update(model);
                //更新用户角色信息。
                UserRoleRelationService.SetRole(model.Id, roleList);
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
            var entity = UserService.Get(primaryKey);
            entity.RoleId = UserRoleRelationService.GetList(entity.Id).Select(c => c.SURRRoleId).ToList();
            entity.DeptName = OrganizeService.Get(entity.SUDepartmentId.ToString()).SOFullName;
            return Content(entity.ToJson());
        }

        [HttpPost, AuthorizeChecked]
        public ActionResult Delete(int userId)
        {
            //多用户删除。
            int row = UserService.Delete(userId);
            return row > 0 ? Success() : Error();
        }

        [HttpPost]
        public ActionResult CheckAccount(string userName)
        {
            var userEntity = UserService.GetByUserName(userName);
            if (userEntity != null)
            {
                return Error("已存在当前用户名，请重新输入");
            }
            return Success("恭喜您，该用户名可以注册");
        }
    }
}
