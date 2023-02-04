using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using System.Security.Claims;

namespace Infrastructure.Identity
{
    public class ClaimsPrincipalFactory : UserClaimsPrincipalFactory<ApplicationUser, ApplicationRole>
    {
        private readonly ITokenService tokenService;

        public ClaimsPrincipalFactory(UserManager<ApplicationUser> userManager, RoleManager<ApplicationRole> roleManager, IOptions<IdentityOptions> options, ITokenService tokenService)
            : base(userManager, roleManager, options)
        {
            this.tokenService = tokenService;
        }

        public async override Task<ClaimsPrincipal> CreateAsync(ApplicationUser user)
        {
            var principal = await base.CreateAsync(user);

            var claims = tokenService.GetClaims(user.Id, user.Email, user.FirstName, user.LastName, user.ImageUrl, user.PhoneNumber, "");
            ((ClaimsIdentity)principal.Identity).AddClaims(claims);

            return principal;
        }
    }
}
