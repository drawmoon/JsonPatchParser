using JsonPatchValidator.Validation;
using JsonPatchValidator.Validation.Default;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace JsonPatchValidator.Extensions
{
    public static class JsonPatchDocumentExtensions
    {
        private static readonly IPatchValidator PatchParser = new PatchValidator();

        public static bool TryVisit<TModel>(this JsonPatchDocument<TModel> patchDoc, out string message) where TModel : class, new()
        {
            return PatchParser.TryVisit(patchDoc, out message);
        }

        public static bool TryVisit<TModel>(this JsonPatchDocument<TModel> patchDoc, ModelStateDictionary modelState) where TModel : class, new()
        {
            return PatchParser.TryVisit(patchDoc, modelState);
        }
    }
}