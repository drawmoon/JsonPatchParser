using Microsoft.AspNetCore.JsonPatch.Operations;
using NInfra.JsonPatchValidator.Commons;
using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace NInfra.JsonPatchValidator.Validation.Defaults
{
    public class DefaultDocumentValidator : IDocumentValidator
    {
        public virtual bool TryValid([NotNull] Operation operation, out string message)
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

        protected static bool VerificationOp(string op, out string message)
        {
            if (string.IsNullOrWhiteSpace(op))
            {
                message = MessageDefaults.OpCannotBeNull;
                return false;
            }

            if (Enum.GetNames(typeof(OperationType)).Count(
                p => string.Equals(p, op, StringComparison.OrdinalIgnoreCase)) != 1)
            {
                message = MessageDefaults.InvalidOp;
                return false;
            }

            message = null;
            return true;
        }
    }
}