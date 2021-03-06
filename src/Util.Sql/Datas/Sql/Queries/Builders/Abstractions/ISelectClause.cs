﻿using System;
using System.Linq.Expressions;

namespace Util.Sql.Datas.Sql.Queries.Builders.Abstractions
{
    /// <summary>
    /// Select子句
    /// </summary>
    public interface ISelectClause {
        /// <summary>
        /// 复制Select子句
        /// </summary>
        /// <param name="sqlBuilder">Sql生成器</param>
        /// <param name="register">实体别名注册器</param>
        ISelectClause Clone(ISqlBuilder sqlBuilder, IEntityAliasRegister register);
        /// <summary>
        /// 过滤重复记录
        /// </summary>
        void Distinct();
        /// <summary>
        /// 设置列名
        /// </summary>
        /// <param name="columns">列名</param>
        /// <param name="tableAlias">表别名</param>
        void Select( string columns, string tableAlias = null );
        /// <summary>
        /// 设置列名
        /// </summary>
        /// <param name="columns">列名</param>
        /// <param name="propertyAsAlias">是否将属性名映射为列别名</param>
        void Select<TEntity>( Expression<Func<TEntity, object[]>> columns,bool propertyAsAlias = false ) where TEntity : class;
        /// <summary>
        /// 设置列名
        /// </summary>
        /// <param name="column">列名</param>
        /// <param name="columnAlias">列别名</param>
        void Select<TEntity>( Expression<Func<TEntity, object>> column, string columnAlias = null ) where TEntity : class;
        /// <summary>
        /// 添加到Select子句
        /// </summary>
        /// <param name="sql">Sql语句</param>
        void AppendSql( string sql );
        /// <summary>
        /// 添加到Select子句
        /// </summary>
        /// <param name="builder">Sql生成器</param>
        /// <param name="columnAlias">列别名</param>
        void AppendSql( ISqlBuilder builder, string columnAlias = null );
        /// <summary>
        /// 输出Sql
        /// </summary>
        string ToSql();
    }
}
