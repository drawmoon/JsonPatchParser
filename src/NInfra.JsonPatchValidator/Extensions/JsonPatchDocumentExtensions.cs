using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using NInfra.JsonPatchValidator.Validation;
using NInfra.JsonPatchValidator.Validation.Defaults;

namespace NInfra.JsonPatchValidator.Extensions
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