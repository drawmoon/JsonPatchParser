using System;
using JsonPatchParser.Validation;
using JsonPatchParser.Validation.Default;
using Microsoft.AspNetCore.JsonPatch.Operations;

namespace JsonPatchParser.Services.Default
{
    public class PatchValidatorFactory : IPatchValidatorFactory
    {
        private readonly DefaultPatchValidator _defaultPatchParser;
        private readonly RemovePatchValidator _removePatchParser;

        public PatchValidatorFactory(DefaultPatchValidator defaultPatchParser, RemovePatchValidator removePatchParser)
        {
            _defaultPatchParser = defaultPatchParser;
            _removePatchParser = removePatchParser;
        }
        
        public IPatchValidator Create(OperationType operationType)
        {
            return operationType switch
            {
                OperationType.Add => (IPatchValidator) _defaultPatchParser,
                OperationType.Remove => (IPatchValidator) _removePatchParser,
                OperationType.Replace => (IPatchValidator) _defaultPatchParser,
                OperationType.Move => (IPatchValidator) _defaultPatchParser,
                OperationType.Copy => (IPatchValidator) _defaultPatchParser,
                OperationType.Test => (IPatchValidator) _defaultPatchParser,
                OperationType.Invalid => (IPatchValidator) _defaultPatchParser,
                _ => throw new ArgumentOutOfRangeException(nameof(operationType), operationType, null)
            };
        }
    }
}