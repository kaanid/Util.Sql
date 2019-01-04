using System;
using System.Collections.Generic;
using System.Text;

namespace Util.Sql.Datas.Sql.Queries.Builders.Abstractions
{
    /// <summary>
    /// delete子句
    /// </summary>
    public interface IDeleteClause
    {
        /// <summary>
        /// 设置表名
        /// </summary>
        /// <param name="table">表名</param>
        /// <param name="alias">别名</param>
        void Delete(string table);
        /// <summary>
        /// 设置表名
        /// </summary>
        /// <param name="alias">别名</param>
        /// <param name="schema">架构名</param>
        void Delete<TEntity>(string schema = null) where TEntity : class;

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
