using Microsoft.AspNetCore.JsonPatch.Operations;
using System;

namespace NInfra.JsonPatchValidator.Validation.Defaults
{
    public static class DocumentValidatorFactory
    {
        public static IDocumentValidator Create(OperationType operationType)
        {
            switch (operationType)
            {
                case OperationType.Add:
                case OperationType.Replace:
                case OperationType.Test:
                    return new DefaultDocumentValidator();
                case OperationType.Move:
                case OperationType.Copy:
                    return new MoveAndCopyDocumentValidator();
                case OperationType.Remove:
                    return new RemoveDocumentValidator();
                case OperationType.Invalid:
                    throw new InvalidOperationException();
                default:
                    throw new ArgumentOutOfRangeException(nameof(operationType), operationType, null);
            }
        }
    }
}