﻿using Microsoft.AspNetCore.JsonPatch.Internal;
using Newtonsoft.Json.Serialization;
using NInfra.JsonPatchValidator.Commons;
using System;
using System.Linq;

namespace NInfra.JsonPatchValidator.Extensions
{
    internal static class PatchValidatorExtensions
    {
        private static readonly IContractResolver ContractResolver = new DefaultContractResolver();

        internal static bool TryValidPath(this Type targetType, ParsedPath parsedPath, out string segment, out string message)
        {
            var location = targetType;

            foreach (var parsedSegment in parsedPath.Segments)
            {
                if (!location.TryGetJsonProperty(parsedSegment, out var jsonProperty))
                {
                    segment = parsedSegment;
                    message = MessageDefaults.PathSegmentNotFound(parsedSegment);
                    return false;
                }

                location = jsonProperty.PropertyType;
            }

            segment = null;
            message = null;
            return true;
        }

        private static bool TryGetJsonProperty(this Type targetType, string parsedSegment, out JsonProperty jsonProperty)
        {
            if (ContractResolver.ResolveContract(targetType) is JsonObjectContract jsonObjectContract)
            {
                jsonProperty = jsonObjectContract.Properties.FirstOrDefault(p => p.PropertyName.Equals(parsedSegment, StringComparison.OrdinalIgnoreCase));

                return jsonProperty != null;
            }

            jsonProperty = null;
            return false;
        }
    }
}