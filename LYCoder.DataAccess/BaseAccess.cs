using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LYCoder.Entity;

namespace LYCoder.DataAccess
{
    /// <summary>
    /// 数据访问层父类。
    /// </summary>
    public partial class BaseAccess<TEntity, TFileFields>
    {
        private static DbContext _db = null;
        public static DbContext Db
        {
            get
            {
                if (_db == null)
                {
                    _db = new DbContext();
                }
                return _db;
            }
        }
        public static bool Exists(object primaryKey)
        {
            return Db.Exists<TEntity>(primaryKey);
        }
        public static TEntity Get(object primaryKey)
        {
            return Db.SingleOrDefault<TEntity>(primaryKey);
        }
        public static int Insert(TEntity model)
        {
            object id = Db.Insert(model);
            return Convert.ToInt32(id);
        }
        public static int Delete(object primaryKey)
        {
            return Db.Delete<TEntity>(primaryKey);
        }
        public static int Delete(TEntity model)
        {
            return Db.Delete(model);
        }
        public static int Update(TEntity model)
        {
            return Db.Update(model);
        }
        public static int Update(TEntity model, IEnumerable<string> columns)
        {
            return Db.Update(model, columns);
        }

        /// <summary>
        /// 列转string 更新
        /// </summary>
        /// <param name="model"></param>
        /// <param name="columns"></param>
        /// <returns></returns>
        public static int Update(TEntity model, IEnumerable<TFileFields> columns)
        {
            var columnsStr = string.Join(",", columns.Select(s => s.ToString())).Split(',').ToList();
            return Db.Update(model, columnsStr);
        }
    }
}
