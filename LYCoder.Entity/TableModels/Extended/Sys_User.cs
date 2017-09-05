using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LYCoder.Entity
{
    public partial class Sys_User
    {

        /// <summary>
        /// 保存角色部门名称。
        /// </summary>
        public string DeptName { get; set; }
        /// <summary>
        /// 登录密码
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// 保存用户角色ID。
        /// </summary>
        public List<int> RoleId { get; set; }

        /// <summary>
        /// 登录时间
        /// </summary>
        public DateTime LoginTime { get; set; }
        /// <summary>
        /// 登录次数
        /// </summary>
        public int LoginCount { get; set; }
        /// <summary>
        /// 消息数
        /// </summary>
        public int MessageCount { get; set; }
    }
}
