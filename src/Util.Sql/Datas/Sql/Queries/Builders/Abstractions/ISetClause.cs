using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Util.Sql.Datas.Sql.Queries.Builders.Abstractions
{
    /// <summary>
    /// set子句
    /// </summary>
    public interface ISetClause
    {
        /// <summary>
        /// 设置表名
        /// </summary>
        /// <param name="table">表名</param>
        void Set(Dictionary<string, object> columns);
        /// <summary>
        /// 设置字段名
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="model"></param>
        void Set<TEntity>(TEntity model) where TEntity : class;
        /// <summary>
        /// 设置字段名
        /// </summary>
        /// <param name="columns">别名</param>
        /// <param name="model">架构名</param>
        void Set<TEntity>(Expression<Func<TEntity, object[]>> columns, TEntity model) where TEntity : class;
        /// <summary>
        /// 验证
        /// </summary>
        void Validate();
        /// <summary>
        /// 输出Sql
        /// </summary>
        string ToSql();
    }
}
