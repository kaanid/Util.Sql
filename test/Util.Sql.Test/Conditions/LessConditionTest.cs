﻿using Util.Sql.Datas.Sql.Queries.Builders.Conditions;
using Xunit;

namespace Util.SqlTest.Sql.Conditions
{
    /// <summary>
    /// Sql小于查询条件测试
    /// </summary>
    public class LessConditionTest {
        /// <summary>
        /// 获取条件
        /// </summary>
        [Fact]
        public void Test() {
            var condition = new LessCondition( "Age", "@Age" );
            Assert.Equal( "Age<@Age", condition.GetCondition() );
        }
    }
}