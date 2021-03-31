using NInfra.LinqExtensions.Search;
using Xunit;

namespace NInfra.LinqExtensions.Tests
{
    public class SearchExpressionTests
    {
        [Fact]
        public void Test1()
        {
            var searchExpression = new SearchExpression("[Name Like 'xiaoli']");

            Assert.Equal("Name", searchExpression.Left);
            Assert.Equal(SearchOperator.Like, searchExpression.Op);
            Assert.Equal("'xiaoli'", searchExpression.Right);
        }

        [Fact]
        public void Test2()
        {
            SearchExpression searchExpression = "[Name Like 'xiaoli']";

            Assert.Equal("Name", searchExpression.Left);
            Assert.Equal(SearchOperator.Like, searchExpression.Op);
            Assert.Equal("'xiaoli'", searchExpression.Right);
        }

        [Fact]
        public void Test3()
        {
            var searchExpression = new SearchExpression("Name", SearchOperator.Like, "'xiaoli'");

            Assert.Equal("Name", searchExpression.Left);
            Assert.Equal(SearchOperator.Like, searchExpression.Op);
            Assert.Equal("'xiaoli'", searchExpression.Right);
        }

        [Fact]
        public void Test4()
        {
            var searchExpression = new SearchExpression("Name", SearchOperator.Like, "'xiaoli'");

            Assert.Equal("[Name Like 'xiaoli']", searchExpression.ToString());
        }
    }
}
