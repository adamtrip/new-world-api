using Application.Identity.Tokens;
using System.Security.Claims;

public interface ITokenService : ITransientService
{
    Task<TokenResponse> GetTokenAsync(TokenRequest request, string ipAddress, CancellationToken cancellationToken, string requestedTenant);
    Task<TokenResponse> RefreshTokenAsync(RefreshTokenRequest request, string ipAddress);
    IEnumerable<Claim> GetClaims(string userId, string email, string firstName, string lastName, string imageUrl, string phoneNumber, string ipAddress);
}