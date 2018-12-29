using Util.Sql.Datas.Queries;
using Util.Sql.Test.Samples;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Util.Sql;

namespace Util.Sql.Test.Queries
{
    public class QueryTest
    {
        private Query<Book, long> _query;
        public QueryTest()
        {
            _query = new Query<Book, long>();
        }

        /// <summary>
        /// 测试获取分页
        /// </summary>
        [Fact]
        public void TestGetPager()
        {
            QueryParameterSample sample = new QueryParameterSample()
            {
                Order = "A",
                Page = 2,
                PageSize = 30,
                TotalCount = 40
            };
            var query = new Query<QueryParameterSample, Guid>(sample);
            query.OrderBy("B", true);
            var pager = query.GetPager();
            Assert.Equal(2, pager.Page);
            Assert.Equal(30, pager.PageSize);
            Assert.Equal(40, pager.TotalCount);
            Assert.Equal("A,B desc", pager.Order);
        }

        /// <summary>
        /// 测试添加查询条件- 当值为空时，不会被忽略
        /// </summary>
        [Fact]
        public void TestWhere()
        {
            _query.Where(t => t.Title == "A");
            Assert.Equal("t => (t.Title == \"A\")", _query.GetPredicate().SafeString());

            _query.Where(t => t.Tel == 1);
            Assert.Equal("t => ((t.Title == \"A\") AndAlso (t.Tel == 1))", _query.GetPredicate().SafeString());

            _query = new Query<Book, long>();
            _query.Where(t => t.Title == "A" && t.Tel == 1);
            Assert.Equal("t => ((t.Title == \"A\") AndAlso (t.Tel == 1))", _query.GetPredicate().SafeString());

            _query = new Query<Book, long>();
            _query.Where(t => t.Title == "");
            Assert.NotNull(_query.GetPredicate());
        }
    }
}
