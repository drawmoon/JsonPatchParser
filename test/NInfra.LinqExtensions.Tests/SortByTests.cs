using NInfra.LinqExtensions.Extensions;
using NInfra.LinqExtensions.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace NInfra.LinqExtensions.Tests
{
    public class SortByTests
    {
        [Fact]
        public void TestSortByExpression()
        {
            var sortExpression = new SortByExpression("[Name Asc]");

            Assert.Equal("Name", sortExpression.Left);
            Assert.Equal(SortOperator.Asc, sortExpression.Op);
        }

        [Fact]
        public void TestSortByExpression2()
        {
            SortByExpression sortExpression = "[Name Asc]";

            Assert.Equal("Name", sortExpression.Left);
            Assert.Equal(SortOperator.Asc, sortExpression.Op);
        }

        [Fact]
        public void TestSortByExpression3()
        {
            var sortExpression = new SortByExpression("Name", SortOperator.Asc);

            Assert.Equal("Name", sortExpression.Left);
            Assert.Equal(SortOperator.Asc, sortExpression.Op);
        }

        [Fact]
        public void TestSortByExpression4()
        {
            var sortExpression = new SortByExpression("Name", SortOperator.Asc);

            Assert.Equal("[Name Asc]", sortExpression.ToString());
        }

        private class Project
        {
            public int Id { get; set; }

            public string Name { get; set; }

            public DateTime CreatedTime { get; set; }
        }

        private static IEnumerable<Project> InitData()
        {
            yield return new Project
            {
                Id = 1,
                Name = "rpo",
                CreatedTime = new DateTime(2018, 6, 12)
            };
            yield return new Project
            {
                Id = 2,
                Name = "哈哈",
                CreatedTime = new DateTime(2018, 10, 24)
            };
            yield return new Project
            {
                Id = 3,
                Name = "97",
                CreatedTime = new DateTime(2019, 3, 16)
            };
            yield return new Project
            {
                Id = 4,
                Name = "1024"
            };
        }

        [Fact]
        public void Test1()
        {
            var query = InitData();

            var list = query.SortBy(new SortByExpression("[Name Asc]"));
            Assert.Equal(4, list.First().Id);
        }

        [Fact]
        public void Test2()
        {
            var query = InitData();

            var list = query.SortBy(new SortByExpression("[CreatedTime Desc]"));
            Assert.Equal(3, list.First().Id);
        }

        [Fact]
        public void Test3()
        {
            var query = InitData();

            var list = query.SortBy(new SortByExpression("[Name Asc]"), new SortByExpression("[CreatedTime Desc]"));
            Assert.Equal(3, list.First().Id);
        }

        [Fact]
        public void Test4()
        {
            var query = InitData();

            var subs = new Dictionary<string, string>
            {
                { "Code", "Id" }
            };
            var list = query.SortBy(subs, new SortByExpression("[Code Asc]"));
            Assert.Equal(1, list.First().Id);
        }
    }
}
