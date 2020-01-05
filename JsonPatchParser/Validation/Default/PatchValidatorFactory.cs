using System;
using Microsoft.AspNetCore.JsonPatch.Operations;

namespace JsonPatchParser.Validation.Default
{
    public static class PatchValidatorFactory
    {
        public static IPatchValidator Create(OperationType operationType)
        {
            switch (operationType)
            {
                case OperationType.Add:
                case OperationType.Replace:
                case OperationType.Move:
                case OperationType.Copy:
                case OperationType.Test:
                case OperationType.Invalid:
                    return new DefaultPatchValidator();
                case OperationType.Remove:
                    return new RemovePatchValidator();
                default:
                    throw new ArgumentOutOfRangeException(nameof(operationType), operationType, null);
            }
        }
    }
}