using Microsoft.AspNetCore.JsonPatch.Operations;

namespace NInfra.JsonPatchValidator.Validation
{
    public interface IDocumentValidator
    {
        bool TryValid(Operation operation, out string message);
    }
}