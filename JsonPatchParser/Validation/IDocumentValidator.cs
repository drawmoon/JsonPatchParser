using Microsoft.AspNetCore.JsonPatch.Operations;

namespace JsonPatchValidator.Validation
{
    public interface IDocumentValidator
    {
        bool IsValid(Operation operation);
    }
}