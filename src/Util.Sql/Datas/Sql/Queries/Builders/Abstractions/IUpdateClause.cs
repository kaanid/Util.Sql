using System;
using System.Collections.Generic;
using System.Text;

namespace Util.Sql.Datas.Sql.Queries.Builders.Abstractions
{
    /// <summary>
    /// Update子句
    /// </summary>
    public interface IUpdateClause
    {
        /// <summary>
        /// 设置表名
        /// </summary>
        /// <param name="table">表名</param>
        /// <param name="alias">别名</param>
        void Update(string table);
        /// <summary>
        /// 设置表名
        /// </summary>
        /// <param name="alias">别名</param>
        /// <param name="schema">架构名</param>
        void Update<TEntity>(string schema = null) where TEntity : class;

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
