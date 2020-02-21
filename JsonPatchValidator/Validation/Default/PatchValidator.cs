using JsonPatchValidator.Extensions;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.JsonPatch.Internal;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;

namespace JsonPatchValidator.Validation.Default
{
    public class PatchValidator : IPatchValidator
    {
        public bool TryVisit<TModel>(JsonPatchDocument<TModel> patchDoc, out string message) where TModel : class, new()
        {
            if (patchDoc == null || patchDoc.Operations == null)
                throw new ArgumentNullException(nameof(patchDoc));

            return TryVisit(patchDoc, out _, out message);
        }

        public bool TryVisit<TModel>(JsonPatchDocument<TModel> patchDoc, ModelStateDictionary modelState) where TModel : class, new()
        {
            if (patchDoc == null || patchDoc.Operations == null)
                throw new ArgumentNullException(nameof(patchDoc));

            if (modelState == null) throw new ArgumentNullException(nameof(modelState));

            if (TryVisit(patchDoc, out var segment, out var message))
                return true;

            modelState.AddModelError(segment, message);
            return false;
        }

        private bool TryVisit<TModel>(JsonPatchDocument<TModel> patchDoc, out string segment, out string message) where TModel : class, new()
        {
            var modelType = typeof(TModel);

            foreach (var operation in patchDoc.Operations)
            {
                var jsonPatchParser = DocumentValidatorFactory.Create(operation.OperationType);

                if (!jsonPatchParser.TryValid(operation, out message))
                {
                    segment = null;
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