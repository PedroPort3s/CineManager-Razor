using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace CineManager.Services.IdentityMultifator
{
    public class IdentityMfa : UserClaimsPrincipalFactory<IdentityUser,IdentityRole>
    {
        public IdentityMfa(UserManager<IdentityUser> userManager,
                RoleManager<IdentityRole> roleManager,
                IOptions<IdentityOptions> optionsAcessor) : base(userManager,roleManager,optionsAcessor)
        {}

        public async override Task<ClaimsPrincipal> CreateAsync(IdentityUser user)
        {
            var principal = await base.CreateAsync(user);
            var identity = (ClaimsIdentity)principal.Identity;

            var claims = new List<Claim>();

            if (user.TwoFactorEnabled)
            {
                claims.Add(new Claim("amr", "mfa"));
            }
            else
            {
                claims.Add(new Claim("amr", "pwd"));
            }

            identity.AddClaims(claims);

            return principal;
        }

    }
}
