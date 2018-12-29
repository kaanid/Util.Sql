﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Util.Sql.Datas.Matedatas
{
    /// <summary>
    /// 实体元数据
    /// </summary>
    public interface IEntityMatedata
    {
        /// <summary>
        /// 获取表名
        /// </summary>
        /// <param name="entity">实体类型</param>
        string GetTable(Type entity);
        /// <summary>
        /// 获取架构
        /// </summary>
        /// <param name="entity">实体类型</param>
        string GetSchema(Type entity);
        /// <summary>
        /// 获取列名
        /// </summary>
        /// <param name="entity">实体类型</param>
        /// <param name="property">属性名</param>
        string GetColumn(Type entity, string property);
    }
}
