using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LYCoder.Entity
{
    /// <summary>
    /// Laytpl + Laypage 分页模型。
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public class LayPadding<TEntity> where TEntity : class
    {
        public int Code { get; set; }

        /// <summary>
        /// 获取结果。
        /// </summary>
        public bool Result { get; set; }

        /// <summary>
        /// 备注信息。
        /// </summary>
        public string Msg { get; set; }

        /// <summary>
        /// 数据列表。
        /// </summary>
        public List<TEntity> List { get; set; }

        /// <summary>
        /// 记录条数。
        /// </summary>
        public long Count { get; set; }
    }
}