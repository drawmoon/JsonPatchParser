using Microsoft.AspNetCore.JsonPatch.Operations;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace JsonPatchValidator.Validation.Default
{
    public class MoveAndCopyDocumentValidator : DefaultDocumentValidator, IDocumentValidator
    {
        public override bool TryValid([NotNull] Operation operation, out string message)
        {
            if (operation == null) throw new ArgumentNullException(nameof(operation));

            if (!VerificationOp(operation.op, out message))
            {
                return false;
            }

            if (string.IsNullOrWhiteSpace(operation.path))
            {
                message = MessageDefaults.PathCannotBeNull;
                return false;
            }

            if (string.IsNullOrWhiteSpace(operation.from))
            {
                message = MessageDefaults.FromCannotBeNull;
                return false;
            }

            message = null;
            return true;
        }
    }
}
