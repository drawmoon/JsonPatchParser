using JsonPatchParser.Validation;
using JsonPatchParser.Validation.Default;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace JsonPatchParser.Extensions
{
    public static class JsonPatchDocumentExtensions
    {
        private static readonly IPatchParser PatchParser = new PatchParser();

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