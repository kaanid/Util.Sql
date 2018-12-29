using Util.Sql.Test.Samples;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Util.Sql.Datas.Queries.Criterias;

namespace Util.Sql.Test.SqlTest.Queries
{
   public  class AndCriteriaTest
   {
        [Fact]
        public void TestGetPredicate()
        {
            var criteria = new AndCriteria<Book>(t=>t.Id==100,t=>t.Title.Contains("123"));

            Assert.Equal("t => ((t.Id == 100) AndAlso t.Title.Contains(\"123\"))", criteria.GetPredicate().ToString());
        }

   }
}
