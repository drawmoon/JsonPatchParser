using JsonPatchParser.Validation;
using Microsoft.AspNetCore.JsonPatch.Operations;

namespace JsonPatchParser.Services
{
    public interface IPatchValidatorFactory
    {
        IPatchValidator Create(OperationType operationType);
    }
}