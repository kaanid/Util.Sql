using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Util.Sql.Datas.Sql
{
    /// <summary>
    /// 数据库
    /// </summary>
    public interface IDatabase
    {
        /// <summary>
        /// 获取数据库连接
        /// </summary>
        IDbConnection GetConnection();
    }
}
