using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LYCoder.Entity
{
    /// <summary>
    /// 通用AJAX请求响应数据格式模型。
    /// </summary>
    public class AjaxResult
    {
        public AjaxResult(ResultType code, string message, object data = null)
        {
            this.State = code;
            this.Message = message;
            this.Data = data;
        }
        /// <summary>
        /// 结果类型。
        /// </summary>
        public object State { get; set; }
        /// <summary>
        /// 消息内容。
        /// </summary>
        public string Message { get; set; }
        /// <summary>
        /// 返回数据。
        /// </summary>
        public object Data { get; set; }
    }

    /// <summary>
    /// 结果类型枚举。
    /// </summary>
    public enum ResultType
    {
        /// <summary>
        /// 警告。
        /// </summary>
        Warning = 0,

        /// <summary>
        /// 成功。
        /// </summary>
        Success = 1,

        /// <summary>
        /// 异常。
        /// </summary>
        Error = 2,

        /// <summary>
        /// 消息。
        /// </summary>
        Info = 6
    }
}