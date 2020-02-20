using Microsoft.AspNetCore.JsonPatch.Operations;
using System;

namespace JsonPatchValidator.Validation.Default
{
    public static class DocumentValidatorFactory
    {
        public static IDocumentValidator Create(OperationType operationType)
        {
            switch (operationType)
            {
                case OperationType.Add:
                case OperationType.Replace:
                case OperationType.Move:
                case OperationType.Copy:
                case OperationType.Test:
                case OperationType.Invalid:
                    return new DefaultDocumentValidator();
                case OperationType.Remove:
                    return new RemoveDocumentValidator();
                default:
                    throw new ArgumentOutOfRangeException(nameof(operationType), operationType, null);
            }
        }
    }
}