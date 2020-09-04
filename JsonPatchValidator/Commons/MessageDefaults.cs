using Microsoft.AspNetCore.JsonPatch.Operations;

namespace JsonPatchValidator.Commons
{
    public static class MessageDefaults
    {
        public static string PathSegmentNotFound(string segment) => $"The target location specified by path segment '{segment}' was not found.";

        public const string ValueCannotBeNull = "Parameter '" + nameof(Operation.value) + "' cannot be null.";
        public const string OpCannotBeNull = "Parameter '" + nameof(Operation.op) + "' cannot be null.";
        public const string InvalidOp = "Invalid" + nameof(Operation.op) + ".";
        public const string PathCannotBeNull = "Parameter '" + nameof(Operation.path) + "' cannot be null.";
        public const string FromCannotBeNull = "Parameter '" + nameof(Operation.from) + "' cannot be null.";
    }
}
