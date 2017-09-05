using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using Newtonsoft.Json;

namespace LYCoder.Entity
{
    /// <summary>
    /// Select2树形下拉列表模型。
    /// </summary>
    public class TreeSelect
    {
        public int id { get; set; }
        public string text { get; set; }
        public int parentId { get; set; }
        public object data { get; set; }
    }

    public static class TreeSelectHelper
    {
        public static string ToTreeSelectJson(this List<TreeSelect> data)
        {
            StringBuilder sb = new StringBuilder();
            if (data != null && data.Count > 0)
            {
                int minPId = data.Min(a => a.parentId);
                sb.Append("[");
                sb.Append(ToTreeSelectJson(data, minPId, minPId, ""));
                sb.Append("]");
            }
            else
            {
                sb.Append("[]");
            }
            return sb.ToString();
        }
        /// <summary>
        /// 绑定TRee
        /// </summary>
        /// <param name="data">数据</param>
        /// <param name="parentId">父ID</param>
        /// <param name="minId">最小父ID</param>
        /// <param name="blank">间隔</param>
        /// <returns></returns>
        private static string ToTreeSelectJson(List<TreeSelect> data, int parentId, int minPId, string blank)
        {
            StringBuilder sb = new StringBuilder();
            var childList = data.FindAll(t => t.parentId == parentId);

            var tabline = "";
            if (parentId != minPId)
            {
                tabline = "　　";
            }
            if (childList.Count > 0)
            {
                tabline = tabline + blank;
            }
            foreach (TreeSelect entity in childList)
            {
                entity.text = tabline + entity.text;
                string strJson = JsonConvert.SerializeObject(entity);
                sb.Append(strJson);
                sb.Append(ToTreeSelectJson(data, entity.id, minPId, tabline));
            }
            return sb.ToString().Replace("}{", "},{");
        }
    }
}