using JsonPatchParser.Extensions;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.JsonPatch.Internal;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace JsonPatchParser.Validation.Default
{
    public class PatchParser : IPatchParser
    {
        public bool TryVisit<TModel>(JsonPatchDocument<TModel> patchDoc, out string message) where TModel : class, new()
        {
            return TryVisit(patchDoc, out _, out message);
        }

        public bool TryVisit<TModel>(JsonPatchDocument<TModel> patchDoc, ModelStateDictionary modelState) where TModel : class, new()
        {
            if (TryVisit(patchDoc, out var segment, out var message))
            {
                return true;
            }
            
            modelState.AddModelError(segment, message);
                
            return false;
        }

        private bool TryVisit<TModel>(JsonPatchDocument<TModel> patchDoc, out string segment, out string message) where TModel : class, new()
        {
            var modelType = typeof(TModel);

            foreach (var operation in patchDoc.Operations)
            {
                var jsonPatchParser = PatchValidatorFactory.Create(operation.OperationType);

                if (!jsonPatchParser.IsValid(operation))
                {
                    segment = null;
                    message = "Format error for JSON Patch.";
                    return false;
                }

                var parsedPath = new ParsedPath(operation.path);

                return modelType.TryValidPath(parsedPath, out segment, out message);
            }

            segment = null;
            message = null;
            return true;
        }
    }
}