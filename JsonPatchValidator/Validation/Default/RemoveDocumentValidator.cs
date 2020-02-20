using Microsoft.AspNetCore.JsonPatch.Operations;

namespace JsonPatchValidator.Validation.Default
{
    public class RemoveDocumentValidator : IDocumentValidator
    {
        public bool IsValid(Operation operation)
        {
            return operation != null &&
                   !string.IsNullOrWhiteSpace(operation.op) &&
                   !string.IsNullOrWhiteSpace(operation.path);
        }
    }
}