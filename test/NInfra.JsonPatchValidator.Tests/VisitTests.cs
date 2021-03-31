using Microsoft.AspNetCore.JsonPatch;
using Newtonsoft.Json;
using NInfra.JsonPatchValidator.Extensions;
using System;
using System.IO;
using Xunit;

namespace NInfra.JsonPatchValidator.Tests
{
    public class VisitTests
    {
        private class Columns
        {
            public int Id { get; set; }

            public string Name { get; set; }

            public string Temp { get; set; }
        }

        private static string ReadJson(string name)
        {
            var path = Path.Combine(AppContext.BaseDirectory.Split("\\bin")[0], $"TestData\\{name}.json");
            return File.ReadAllText(path);
        }

        [Theory]

        [InlineData("add-1", null)]
        [InlineData("add-2", "Parameter 'path' cannot be null.")]
        [InlineData("add-3", "The target location specified by path segment 'name1' was not found.")]

        [InlineData("remove-1", null)]
        [InlineData("remove-2", "Parameter 'path' cannot be null.")]
        [InlineData("remove-3", "The target location specified by path segment 'name1' was not found.")]

        [InlineData("replace-1", null)]
        [InlineData("replace-2", "Parameter 'path' cannot be null.")]
        [InlineData("replace-3", "The target location specified by path segment 'name1' was not found.")]

        [InlineData("move-1", null)]
        [InlineData("move-2", "Parameter 'from' cannot be null.")]
        [InlineData("move-3", "Parameter 'path' cannot be null.")]
        [InlineData("move-4", "The target location specified by path segment 'name1' was not found.")]

        [InlineData("copy-1", null)]
        [InlineData("copy-2", "Parameter 'from' cannot be null.")]
        [InlineData("copy-3", "Parameter 'path' cannot be null.")]
        [InlineData("copy-4", "The target location specified by path segment 'name1' was not found.")]

        [InlineData("test-1", null)]
        [InlineData("test-2", "Parameter 'path' cannot be null.")]
        [InlineData("test-3", "The target location specified by path segment 'name1' was not found.")]
        public void Test1(string name, string message)
        {
            var json = ReadJson(name);
            var patchDoc = JsonConvert.DeserializeObject<JsonPatchDocument<Columns>>(json);
            var succeed = patchDoc.TryVisit(out var errorMessage);
            if (errorMessage != null)
            {
                Assert.False(succeed);
            }
            else
            {
                Assert.True(succeed);
            }
            Assert.Equal(message, errorMessage);
        }
    }
}
