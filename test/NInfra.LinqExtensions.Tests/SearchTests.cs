using NInfra.LinqExtensions.Models;
using Xunit;

namespace NInfra.LinqExtensions.Tests
{
    public class SearchTests
    {
        [Fact]
        public void TestSearchExpression1()
        {
            var searchExpression = new SearchExpression("[Name Like 'xiaoli']");

            Assert.Equal("Name", searchExpression.Left);
            Assert.Equal(SearchOperator.Like, searchExpression.Op);
            Assert.Equal("'xiaoli'", searchExpression.Right);
        }

        [Fact]
        public void TestSearchExpression2()
        {
            SearchExpression searchExpression = "[Name Like 'xiaoli']";

            Assert.Equal("Name", searchExpression.Left);
            Assert.Equal(SearchOperator.Like, searchExpression.Op);
            Assert.Equal("'xiaoli'", searchExpression.Right);
        }

        [Fact]
        public void TestSearchExpression3()
        {
            var searchExpression = new SearchExpression("Name", SearchOperator.Like, "'xiaoli'");

            Assert.Equal("Name", searchExpression.Left);
            Assert.Equal(SearchOperator.Like, searchExpression.Op);
            Assert.Equal("'xiaoli'", searchExpression.Right);
        }

        [Fact]
        public void TestSearchExpression4()
        {
            var searchExpression = new SearchExpression("Name", SearchOperator.Like, "'xiaoli'");

            Assert.Equal("[Name Like 'xiaoli']", searchExpression.ToString());
        }
    }
}
