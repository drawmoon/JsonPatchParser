using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace NInfra.JsonPatchValidator.Validation
{
    public interface IPatchValidator
    {
        bool TryVisit<TModel>(JsonPatchDocument<TModel> patchDoc, out string message) where TModel : class, new();

        bool TryVisit<TModel>(JsonPatchDocument<TModel> patchDoc, ModelStateDictionary modelState) where TModel : class, new();
    }
}