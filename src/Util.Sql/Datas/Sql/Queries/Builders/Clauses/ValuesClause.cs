using Util.Sql.Datas.Sql.Queries.Builders.Abstractions;
using Util.Sql.Datas.Sql.Queries.Builders.Core;
using Util.Sql.Datas.Sql.Queries.Builders.Internal;
using Util.Sql.Helpers;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Util.Sql.Datas.Sql.Queries.Builders.Clauses
{
    public class ValuesClause : IValuesClause
    {
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
        /// 参数管理器
        /// </summary>
        private readonly IParameterManager _parameterManager;
        /// <summary>
        /// 辅助操作
        /// </summary>
        private readonly Helper _helper;

        /// <summary>
        /// 列名集合
        /// </summary>
        private readonly Dictionary<string,string> _columns;

        /// <summary>
        /// 初始化delete子句
        /// </summary>
        /// <param name="dialect">方言</param>
        /// <param name="resolver">实体解析器</param>
        /// <param name="register">实体别名注册器</param>
        public ValuesClause(IDialect dialect, IEntityResolver resolver, IEntityAliasRegister register, IParameterManager parameterManager)
        {
            _columns = new Dictionary<string, string>();
            _dialect = dialect;
            _resolver = resolver;
            _register = register;
            _parameterManager = parameterManager;
            _helper = new Helper(dialect, resolver, register, parameterManager);
        }

        public void Values(Dictionary<string,object> columns)
        {
            if (columns == null || columns.Count == 0)
                throw new ArgumentNullException(nameof(columns));

            foreach (var kv in columns)
            {
                var paramName = _parameterManager.GenerateName();
                _parameterManager.Add(paramName, kv.Value,Datas.Queries.Operator.Equal);
                _columns.Add(kv.Key, paramName);
            }
        }

        public void Values<TEntity>(TEntity model) where TEntity : class
        {
            var type = typeof(TEntity);
            var members = type.GetProperties(System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance);
            foreach (var m in members)
            {
                var paramName = _parameterManager.GenerateName();
                object obj = m.GetValue(model);
                _parameterManager.Add(paramName, obj, Datas.Queries.Operator.Equal);
                _columns.Add(m.Name, paramName);
            }
        }

        public void Values<TEntity>(Expression<Func<TEntity, object[]>> columns, TEntity model) where TEntity : class
        {
            var names = Lambda.GetLastNames(columns);
            if (names == null || names.Count == 0)
                throw new ArgumentNullException(nameof(names));

            var type= typeof(TEntity);
            var members=type.GetProperties(System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance);
            foreach(var m in members)
            {
                if(names.Contains(m.Name))
                {
                    var paramName = _parameterManager.GenerateName();
                    object obj= m.GetValue(model);
                    _parameterManager.Add(paramName, obj, Datas.Queries.Operator.Equal);
                    _columns.Add(m.Name, paramName);
                }
            }
        }

        public string ToSql()
        {
            StringBuilder sbKey = new StringBuilder();
            StringBuilder sbValue = new StringBuilder();
            sbKey.Append("(");
            sbValue.Append("Values(");
            foreach (var kv in _columns)
            {
                var colume = GetSafeName(_dialect, kv.Key);
                sbKey.Append($"{colume},");
                sbValue.Append($"{kv.Value},");
            }
            sbKey.Length = sbKey.Length - 1;
            sbKey.Append(")");
            sbValue.Length = sbValue.Length - 1;
            sbValue.Append(")");

            //sbKey.AppendLine(sbValue.ToString());

            return sbKey.ToString()+Environment.NewLine+sbValue.ToString();
        }

        public void Validate()
        {
            if(_columns.Count==0)
                throw new ArgumentOutOfRangeException(nameof(_columns));
        }

        /// <summary>
        /// 获取安全名称
        /// </summary>
        private string GetSafeName(IDialect dialect, string name)
        {
            if (dialect == null)
                return name;
            return dialect.SafeName(name);
        }
    }
}
