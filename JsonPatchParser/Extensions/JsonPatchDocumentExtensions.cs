using JsonPatchParser.Services.Default;
using JsonPatchParser.Validation;
using JsonPatchParser.Validation.Default;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace JsonPatchParser.Extensions
{
    public static class JsonPatchDocumentExtensions
    {
        private static readonly IPatchParser PatchParser;

        static JsonPatchDocumentExtensions()
        {
            var defaultPatchValidator = new DefaultPatchValidator();
            var removePatchValidator = new RemovePatchValidator();
            var patchValidatorFactory = new PatchValidatorFactory(defaultPatchValidator, removePatchValidator);
            PatchParser = new PatchParser(patchValidatorFactory);
        }
        
        public static bool TryVisit<TModel>(this JsonPatchDocument<TModel> patchDoc, out string message) where TModel : class, new()
        {
            return PatchParser.TryVisit(patchDoc, out message);
        }

        public static bool TryVisit<TModel>(JsonPatchDocument<TModel> patchDoc, ModelStateDictionary modelState) where TModel : class, new()
        {
            return PatchParser.TryVisit(patchDoc, modelState);
        }
    }
}