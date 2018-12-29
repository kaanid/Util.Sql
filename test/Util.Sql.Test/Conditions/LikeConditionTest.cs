using Util.Sql.Datas.Sql.Queries.Builders.Conditions;
using Xunit;

namespace Util.SqlTest.Sql.Conditions
{
    /// <summary>
    /// Sql模糊查询条件测试
    /// </summary>
    public class LikeConditionTest {
        /// <summary>
        /// 获取条件
        /// </summary>
        [Fact]
        public void Test() {
            var condition = new LikeCondition( "Name", "@Name" );
            Assert.Equal( "Name Like @Name", condition.GetCondition() );
        }
    }
}