using Util.Sql.Datas.Sql.Queries.Builders.Abstractions;
using Util.Sql.Datas.Sql.Queries.Builders.Core;
using Util.Sql.Datas.Sql.Queries.Builders.Extensions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Util.Sql.Datas.Sql.Queries.Builders.Clauses
{
    /// <summary>
    /// delete子句
    /// </summary>
    public class InsertClause : IInsertClause
    {
        /// <summary>
        /// Sql项
        /// </summary>
        private SqlItem _item;
        /// <summary>
        /// 方言
        /// </summary>
        private readonly IDialect _dialect;
        /// <summary>
        /// 实体解析器
        /// </summary>
        private readonly IEntityResolver _resolver;
        /// <summary>
        /// 实体注册器
        /// </summary>
        private readonly IEntityAliasRegister _register;

        /// <summary>
        /// 初始化delete子句
        /// </summary>
        /// <param name="dialect">方言</param>
        /// <param name="resolver">实体解析器</param>
        /// <param name="register">实体别名注册器</param>
        public InsertClause(IDialect dialect, IEntityResolver resolver, IEntityAliasRegister register)
        {
            _dialect = dialect;
            _resolver = resolver;
            _register = register;
        }

        public void Insert(string table)
        {
            _item = CreateSqlItem(table, null, null);
        }

        public void Insert<TEntity>(string schema = null) where TEntity : class
        {
            var entity = typeof(TEntity);
            string table = _resolver.GetTableAndSchema2(entity);
            _item = CreateSqlItem(table, schema, null);
            _register.Register(entity, _resolver.GetAlias(entity, null));
        }

        /// <summary>
        /// 创建Sql项
        /// </summary>
        /// <param name="table">表名</param>
        /// <param name="schema">架构名</param>
        /// <param name="alias">别名</param>
        protected virtual SqlItem CreateSqlItem(string table, string schema, string alias)
        {
            return new SqlItem(table, schema, alias);
        }

        public string ToSql()
        {
            var table = _item?.ToSql(_dialect);
            if (string.IsNullOrWhiteSpace(table))
                return null;
            return $"Insert into {table}";
        }

        public void Validate()
        {
            if (string.IsNullOrWhiteSpace(_item?.Name))
                throw new InvalidOperationException("必须设置表名");
        }
    }
}
