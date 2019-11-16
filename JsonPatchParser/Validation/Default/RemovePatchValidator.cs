using Microsoft.AspNetCore.JsonPatch.Operations;

namespace JsonPatchParser.Validation.Default
{
    public class RemovePatchValidator : IPatchValidator
    {
        public bool IsValid(Operation operation)
        {
            return operation != null &&
                   !string.IsNullOrWhiteSpace(operation.op) &&
                   !string.IsNullOrWhiteSpace(operation.path);
        }
    }
}