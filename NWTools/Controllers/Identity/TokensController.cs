using Application.Identity.Tokens;
using Infrastructure.OpenApi;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NSwag.Annotations;

namespace NWTools.Controllers.Identity;

public sealed class TokensController : VersionNeutralApiController
{
    private readonly ITokenService _tokenService;

    public TokensController(ITokenService tokenService) => _tokenService = tokenService;

    [HttpPost]
    [AllowAnonymous]
    [TenantIdHeader]
    [OpenApiOperation("Request an access token using credentials.", "")]
    public Task<TokenResponse> GetTokenAsync(TokenRequest request, CancellationToken cancellationToken)
    {
        var requestedTentant = Request.Headers.First(x => x.Key == "tenant").Value;
        return _tokenService.GetTokenAsync(request, GetIpAddress(), cancellationToken, requestedTentant);
    }

    //[HttpPost("refresh")]
    //[AllowAnonymous]
    //[TenantIdHeader]
    //[OpenApiOperation("Request an access token using a refresh token.", "")]
    //[ApiConventionMethod(typeof(FSHApiConventions), nameof(FSHApiConventions.Search))]
    //public Task<TokenResponse> RefreshAsync(RefreshTokenRequest request)
    //{
    //    return _tokenService.RefreshTokenAsync(request, GetIpAddress());
    //}

    private string GetIpAddress() =>
        Request.Headers.ContainsKey("X-Forwarded-For")
            ? Request.Headers["X-Forwarded-For"]
            : HttpContext.Connection.RemoteIpAddress?.MapToIPv4().ToString() ?? "N/A";
}