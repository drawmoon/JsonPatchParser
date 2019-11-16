using Microsoft.AspNetCore.JsonPatch.Operations;

namespace JsonPatchParser.Validation
{
    public interface IPatchValidator
    {
        bool IsValid(Operation operation);
    }
}