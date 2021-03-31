using NInfra.LinqExtensions.Sort;
using Xunit;

namespace NInfra.LinqExtensions.Tests
{
    public class SortByExpressionTests
    {
        [Fact]
        public void Test1()
        {
            var sortExpression = new SortByExpression("[Name Asc]");

            Assert.Equal("Name", sortExpression.Left);
            Assert.Equal(SortOperator.Asc, sortExpression.Op);
        }

        [Fact]
        public void Test2()
        {
            SortByExpression sortExpression = "[Name Asc]";

            Assert.Equal("Name", sortExpression.Left);
            Assert.Equal(SortOperator.Asc, sortExpression.Op);
        }

        [Fact]
        public void Test3()
        {
            var sortExpression = new SortByExpression("Name", SortOperator.Asc);

            Assert.Equal("Name", sortExpression.Left);
            Assert.Equal(SortOperator.Asc, sortExpression.Op);
        }

        [Fact]
        public void Test4()
        {
            var sortExpression = new SortByExpression("Name", SortOperator.Asc);

            Assert.Equal("[Name Asc]", sortExpression.ToString());
        }
    }
}
