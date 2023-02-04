using Application.Common.DynamicEvaluator;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.DynamicEvaluator;

internal static class Startup
{
    internal static IServiceCollection AddDynamicEvaluator(this IServiceCollection services)
    {
        return services.AddTransient<IDynamicEvaluator, DynamicEvaluator>();
    }
}