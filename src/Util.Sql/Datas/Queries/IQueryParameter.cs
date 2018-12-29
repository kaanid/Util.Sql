using Util.Sql.Domains.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Util.Sql.Datas.Queries
{
    /// <summary>
    /// 查询参数
    /// </summary>
    public interface IQueryParameter : IPager
    {
        /// <summary>
        /// 搜索关键字
        /// </summary>
        string Keyword { get; set; }
    }
}
