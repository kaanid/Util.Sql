using System;
using System.Collections.Generic;
using System.Text;

namespace Util.Sql.Domains
{
    /// <summary>
    /// 逻辑删除
    /// </summary>
    public interface IDelete
    {
        /// <summary>
        /// 是否删除
        /// </summary>
        bool IsDeleted { get; set; }
    }
}
