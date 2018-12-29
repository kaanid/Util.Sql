﻿using Util.Sql.Datas.Matedatas;
using Util.Sql.Datas.Sql.Queries.Builders.Abstractions;
using Util.Sql.Datas.Sql.Queries.Builders.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Util.Sql.Datas.SqlServer
{
    /// <summary>
    /// Sql Server Sql生成器
    /// </summary>
    public class SqlServerBuilder : SqlBuilderBase
    {
        /// <summary>
        /// 初始化Sql生成器
        /// </summary>
        /// <param name="matedata">实体元数据解析器</param>
        /// <param name="parameterManager">参数管理器</param>
        public SqlServerBuilder(IEntityMatedata matedata = null, IParameterManager parameterManager = null) : base(matedata, parameterManager)
        {
        }

        /// <summary>
        /// 获取Sql方言
        /// </summary>
        protected override IDialect GetDialect()
        {
            return new SqlServerDialect();
        }

        /// <summary>
        /// 创建Sql生成器
        /// </summary>
        public override ISqlBuilder New()
        {
            return new SqlServerBuilder(EntityMatedata, ParameterManager);
        }

        /// <summary>
        /// 创建分页Sql
        /// </summary>
        protected override void CreatePagerSql(StringBuilder result)
        {
            AppendSelect(result);
            AppendFrom(result);
            AppendSql(result, GetJoin());
            AppendSql(result, GetWhere());
            AppendSql(result, GetGroupBy());
            AppendSql(result, GetOrderBy());
            result.Append($"Offset { GetSkipCountParam() } Rows Fetch Next { GetPageSizeParam() } Rows Only");
        }
    }
}
