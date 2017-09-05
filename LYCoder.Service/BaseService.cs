using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LYCoder.DataAccess;

namespace LYCoder.Service
{
    /// <summary>
    /// 业务逻辑层父类。
    /// </summary>
    public partial class BaseService<TEntity> 
    {
        public static bool Exists(object primaryKey)
        {
            return BaseAccess<TEntity>.Exists(primaryKey);
        }

        public static TEntity Get(object primaryKey)
        {
            return BaseAccess<TEntity>.Get(primaryKey);
        }

        public static int Insert(TEntity model)
        {
            return BaseAccess<TEntity>.Insert(model);
        }

        public static int Update(TEntity model)
        {
            return BaseAccess<TEntity>.Update(model);
        }

        public static int Delete(object primaryKey)
        {
            return BaseAccess<TEntity>.Delete(primaryKey);
        }

    }
}
