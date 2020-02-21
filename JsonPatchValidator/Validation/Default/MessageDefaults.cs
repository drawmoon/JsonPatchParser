using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.JsonPatch.Operations;
using System;
using System.Collections.Generic;
using System.Text;

namespace JsonPatchValidator.Validation.Default
{
    public static class MessageDefaults
    {
        public const string ValueCannotBeNull = "Parameter '" + nameof(Operation.value) + "' cannot be null.";
        public const string OpCannotBeNull = "Parameter '" + nameof(Operation.op) + "' cannot be null.";
        public const string InvalidOp = "Invalid" + nameof(Operation.op) + ".";
        public const string PathCannotBeNull = "Parameter '" + nameof(Operation.path) + "' cannot be null.";
        public const string FromCannotBeNull = "Parameter '" + nameof(Operation.from) + "' cannot be null.";
    }
}
