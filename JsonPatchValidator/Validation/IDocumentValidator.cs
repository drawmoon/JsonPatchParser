using Microsoft.AspNetCore.JsonPatch.Operations;

namespace JsonPatchValidator.Validation
{
    public interface IDocumentValidator
    {
        bool TryValid(Operation operation, out string message);
    }
}