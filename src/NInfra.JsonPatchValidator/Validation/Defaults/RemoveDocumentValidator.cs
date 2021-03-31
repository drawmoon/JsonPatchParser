using Microsoft.AspNetCore.JsonPatch.Operations;
using NInfra.JsonPatchValidator.Commons;
using System;
using System.Diagnostics.CodeAnalysis;

namespace NInfra.JsonPatchValidator.Validation.Defaults
{
    public class RemoveDocumentValidator : DefaultDocumentValidator, IDocumentValidator
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

            message = null;
            return true;
        }
    }
}