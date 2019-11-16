// ReSharper disable CheckNamespace

using JsonPatchParser.Services;
using JsonPatchParser.Services.Default;
using JsonPatchParser.Validation;
using JsonPatchParser.Validation.Default;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class JsonPatchParserServiceCollectionExtensions
    {
        public static IServiceCollection AddJsonPatchParser(this IServiceCollection services)
        {
            services.TryAddSingleton<DefaultPatchValidator>();
            services.TryAddSingleton<RemovePatchValidator>();
            services.TryAddSingleton<IPatchValidatorFactory, PatchValidatorFactory>();
            services.TryAddSingleton<IPatchParser, PatchParser>();
            return services;
        }
    }
}