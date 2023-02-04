using Application.Common.DynamicEvaluator;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;

namespace Infrastructure.DynamicEvaluator;

internal static class Startup
{
    internal static IServiceCollection AddDynamicEvaluator(this IServiceCollection services)
    {
        return services.AddTransient<IDynamicEvaluator, DynamicEvaluator>();
    }
}