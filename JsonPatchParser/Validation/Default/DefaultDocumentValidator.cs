using Microsoft.AspNetCore.JsonPatch.Operations;

namespace JsonPatchValidator.Validation.Default
{
    public class DefaultDocumentValidator : IDocumentValidator
    {
        public bool IsValid(Operation operation)
        {
            return operation?.value != null &&
                   (!(operation.value is string str) || !string.IsNullOrWhiteSpace(str)) &&
                   !string.IsNullOrWhiteSpace(operation.op) &&
                   !string.IsNullOrWhiteSpace(operation.path);
        }
    }
}