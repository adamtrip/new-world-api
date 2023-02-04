using Infrastructure.Persistence.Context;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Infrastructure.Identity;

internal static class Startup
{
    internal static IServiceCollection AddIdentity(this IServiceCollection services, IConfiguration configuration, IHostEnvironment hostEnvironment) =>

         services
            .AddIdentity<ApplicationUser, ApplicationRole>(options =>
            {
                options.Password.RequiredLength = 6;
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.User.RequireUniqueEmail = true;
            })
            .AddEntityFrameworkStores<ApplicationDbContext>()
            .AddDefaultTokenProviders()
            .Services;
    //services
    //    .AddIdentity<ApplicationUser, ApplicationRole>(options =>
    //    {
    //        options.Password.RequiredLength = 6;
    //        options.Password.RequireDigit = false;
    //        options.Password.RequireLowercase = false;
    //        options.Password.RequireNonAlphanumeric = false;
    //        options.Password.RequireUppercase = false;
    //        options.User.RequireUniqueEmail = true;
    //    })
    //    .AddEntityFrameworkStores<ApplicationDbContext>()
    //    .AddDefaultTokenProviders()
    //.Services
    //.Configure<CookiePolicyOptions>(options =>
    //{
    //    // This lambda determines whether user consent for non-essential cookies is needed for a given request.
    //    options.CheckConsentNeeded = context => true;
    //    options.MinimumSameSitePolicy = SameSiteMode.None;
    //})
    //.ConfigureApplicationCookie(config =>
    //{
    //    config.Cookie.Name = ".AspNet.CentralService";
    //    config.LoginPath = "/identity/account/login";
    //    if (hostEnvironment.IsProduction()) config.Cookie.Domain = ".prplex.pt";
    //})
    //.AddTransient<IUserClaimsPrincipalFactory<ApplicationUser>, ClaimsPrincipalFactory>();

}