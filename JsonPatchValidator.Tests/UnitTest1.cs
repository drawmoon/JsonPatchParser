using JsonPatchValidator.Extensions;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.JsonPatch.Operations;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using Xunit;

namespace JsonPatchValidator.Tests
{
    public class UnitTest1
    {
        [Theory]

        [InlineData("add", "/name", "", "xiaoli", true, null)]
        [InlineData("add", "/name", "", "", false, "Parameter 'value' cannot be null.")]
        [InlineData("add", "", "", "xiaoli", false, "Parameter 'path' cannot be null.")]
        [InlineData("add", "/name1", "", "xiaoli", false, "The target location specified by path segment 'name1' was not found.")]

        [InlineData("remove", "/name", "", "", true, null)]
        [InlineData("remove", "", "", "", false, "Parameter 'path' cannot be null.")]
        [InlineData("remove", "/name1", "", "", false, "The target location specified by path segment 'name1' was not found.")]

        [InlineData("replace", "/name", "", "xiaoli", true, null)]
        [InlineData("replace", "/name", "", "", false, "Parameter 'value' cannot be null.")]
        [InlineData("replace", "", "", "xiaoli", false, "Parameter 'path' cannot be null.")]
        [InlineData("replace", "/name1", "", "xiaoli", false, "The target location specified by path segment 'name1' was not found.")]

        [InlineData("move", "/name", "/temp", "", true, null)]
        [InlineData("move", "/name", "", "", false, "Parameter 'from' cannot be null.")]
        [InlineData("move", "", "/temp", "", false, "Parameter 'path' cannot be null.")]
        [InlineData("move", "/name1", "/temp", "", false, "The target location specified by path segment 'name1' was not found.")]

        [InlineData("copy", "/name", "/temp", "", true, null)]
        [InlineData("copy", "/name", "", "", false, "Parameter 'from' cannot be null.")]
        [InlineData("copy", "", "/temp", "", false, "Parameter 'path' cannot be null.")]
        [InlineData("copy", "/name1", "/temp", "", false, "The target location specified by path segment 'name1' was not found.")]

        [InlineData("test", "/name", "", "xiaoli", true, null)]
        [InlineData("test", "/name", "", "", false, "Parameter 'value' cannot be null.")]
        [InlineData("test", "", "", "xiaoli", false, "Parameter 'path' cannot be null.")]
        [InlineData("test", "/name1", "", "xiaoli", false, "The target location specified by path segment 'name1' was not found.")]
        public void Test1(string op, string path, string from, string value, bool expectedResult, string expectedMessage)
        {
            var operations = new List<Operation<Columns>>
            {
                new Operation<Columns>(op, path, from, value)
            };
            var patchDoc = new JsonPatchDocument<Columns>(operations, new DefaultContractResolver());
            var result = patchDoc.TryVisit(out var message);
            Assert.Equal(expectedResult, result);
            Assert.Equal(expectedMessage, message);
        }
    }
}
