﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LYCoder.Common;
using LYCoder.Entity;
using LYCoder.DataAccess;

namespace LYCoder.Service
{
    public partial class RoleService : BaseService<Sys_Role>
    {
        public static Page<Sys_Role> GetList(long pageIndex, long pageSize, string keyWord)
        {
            return RoleAccess.GetList(pageIndex, pageSize, keyWord);
        }

        public static new int Insert(Sys_Role model)
        {
            model.SRIsEnabled = 1;
            model.SRDeleteMark = 0;
            model.SRCreateUser = OperatorProvider.Instance.Current.UserId;
            model.SRCreateTime = DateTime.Now;
            model.SRModifyUser = model.SRCreateUser;
            model.SRModifyTime = model.SRCreateTime;
            return RoleAccess.Insert(model);
        }

        public static new  int Update(Sys_Role model)
        {
            model.SRModifyUser = OperatorProvider.Instance.Current.UserId;
            model.SRCreateTime = DateTime.Now; ;
            model.SRModifyTime = DateTime.Now;
            var updateColumns = new List<string>() {
                "SROrganizeId", "SREnCode", "SRType", "SRName", "SRAllowEdit",
                "SRIsEnabled", "SRRemark", "SRSortCode", "SRModifyUser", "SRModifyTime" };
            return RoleAccess.Update(model, updateColumns);
        }

        public static int Delete(string[] primaryKeys)
        {
            return RoleAccess.Delete(primaryKeys);
        }

        public static List<Sys_Role> GetList()
        {
            return RoleAccess.GetList();
        }
    }
}
