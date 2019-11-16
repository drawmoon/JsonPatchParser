using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace JsonPatchParser.Validation
{
    public interface IPatchParser
    {
        bool TryVisit<TModel>(JsonPatchDocument<TModel> patchDoc, out string message) where TModel : class, new();
        
        bool TryVisit<TModel>(JsonPatchDocument<TModel> patchDoc, ModelStateDictionary modelState) where TModel : class, new();
    }
}