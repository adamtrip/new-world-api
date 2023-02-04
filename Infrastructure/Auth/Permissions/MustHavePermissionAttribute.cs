using Application.Identity.Users;
using HotChocolate.AspNetCore.Authorization;
using HotChocolate.Resolvers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Share.Authorization;

namespace Infrastructure.Auth.Permissions;

//public class MustHavePermissionAttribute : AuthorizeAttribute//, IAuthorizationFilter
//{
//    public MustHavePermissionAttribute(string action, string resource, string application)
//    {
//        Policy = FSHPermission.NameFor(action, resource, application);
//        AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme + "," + IdentityConstants.ApplicationScheme;
//    }

//    public void OnAuthorization(AuthorizationFilterContext context)
//    {
//        var userId = context.HttpContext.User.GetUserId();
//        context.HttpContext.Request.Headers.TryGetValue("tenant", out var tenantId);
//        if (string.IsNullOrEmpty(tenantId))
//        {
//            var tenantClaim = context.HttpContext.User.Claims.FirstOrDefault(x => x.Type == "tenant");
//            if (tenantClaim != null) tenantId = tenantClaim.Value;
//        }
//        var userService = context.HttpContext.RequestServices.GetService(typeof(IUserService)) as IUserService;
//        var result = userService.HasAccessToTenantAsync(userId, tenantId).Result;
//        if (!result) context.Result = new UnauthorizedResult();

//    }
//}

public class MustHavePermissionAttribute : Microsoft.AspNetCore.Authorization.AuthorizeAttribute
{
    public MustHavePermissionAttribute(string action, string resource, string application) =>
        Policy = FSHPermission.NameFor(action, resource, application);

    public void OnAuthorization(AuthorizationFilterContext context)
    {
        var userId = context.HttpContext.User.GetUserId();
        context.HttpContext.Request.Headers.TryGetValue("tenant", out var tenantId);
        if (string.IsNullOrEmpty(tenantId))
        {
            var tenantClaim = context.HttpContext.User.Claims.FirstOrDefault(x => x.Type == "tenant");
            if (tenantClaim != null) tenantId = tenantClaim.Value;
        }
        var userService = context.HttpContext.RequestServices.GetService(typeof(IUserService)) as IUserService;
        var result = userService.HasAccessToTenantAsync(userId, tenantId).Result;
        if (!result) context.Result = new UnauthorizedResult();

    }
}

public class GraphQLAuthorizationHandler : HotChocolate.AspNetCore.Authorization.IAuthorizationHandler
{

    public async ValueTask<AuthorizeResult> AuthorizeAsync(IMiddlewareContext context, AuthorizeDirective directive)
    {
        var authorizeResult = AuthorizeResult.NotAllowed;
        var httpContextAccessor = context.Services.GetService(typeof(IHttpContextAccessor)) as IHttpContextAccessor;
        var userService = httpContextAccessor.HttpContext.RequestServices.GetService(typeof(IUserService)) as IUserService;
        var userId = httpContextAccessor.HttpContext.User.GetUserId();
        if (!string.IsNullOrEmpty(userId))
        {
            if (await userService.HasAPITokenAcess(userId)) authorizeResult = AuthorizeResult.Allowed;
            else authorizeResult = AuthorizeResult.NotAllowed;
        }
        else
            authorizeResult = AuthorizeResult.NotAllowed;

        return await Task.FromResult(((Func<AuthorizeResult>)(() =>
        {
            return authorizeResult;

        }))());
    }
}
