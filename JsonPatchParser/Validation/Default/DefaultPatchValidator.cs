using Microsoft.AspNetCore.JsonPatch.Operations;

namespace JsonPatchParser.Validation.Default
{
    public class DefaultPatchValidator : IPatchValidator
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