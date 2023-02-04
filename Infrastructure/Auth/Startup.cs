using Application.Common.Interfaces;
using Infrastructure.Auth.Jwt;
using Infrastructure.Auth.Permissions;
using Infrastructure.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Infrastructure.Auth;

internal static class Startup
{
    internal static IServiceCollection AddAuth(this IServiceCollection services, IConfiguration config, IHostEnvironment environment)
    {
        return services
            .AddCurrentUser()

            // Must add identity before adding auth!
            .AddIdentity(config, environment)
            .AddPermissions()
            .AddJwtAuth(config);
        //services.Configure<SecuritySettings>(config.GetSection(nameof(SecuritySettings)));
        //return config["SecuritySettings:Provider"].Equals("AzureAd", StringComparison.OrdinalIgnoreCase)
        //    ? services.AddAzureAdAuth(config)
        //    : services.AddJwtAuth(config);
    }

    internal static IApplicationBuilder UseCurrentUser(this IApplicationBuilder app) =>
        app.UseMiddleware<CurrentUserMiddleware>();

    private static IServiceCollection AddCurrentUser(this IServiceCollection services) =>
        services
            .AddTransient<CurrentUserMiddleware>()
            .AddTransient<ICurrentUser, CurrentUser>()
            .AddTransient(sp => (ICurrentUserInitializer)sp.GetRequiredService<ICurrentUser>());

    private static IServiceCollection AddPermissions(this IServiceCollection services) =>
        services
            .AddSingleton<IAuthorizationPolicyProvider, PermissionPolicyProvider>()
            .AddTransient<IAuthorizationHandler, PermissionAuthorizationHandler>();
}