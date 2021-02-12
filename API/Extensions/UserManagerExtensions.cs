using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Core.Entities.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace API.Extensions
{
    public static class UserManagerExtensions
    {
        public static async Task<AppUser> FindUserByClaimsPrincipalWithAddressAsync(this UserManager<AppUser> userManager, ClaimsPrincipal claims)
        {
            var email = claims.Claims?.FirstOrDefault(x => x.Type == ClaimTypes.Email)?.Value;
            // return await _context.CustomerBasket.Include(p => p.Items).FirstOrDefaultAsync(p => p.Id == basketId);
            var user = await userManager.Users.Include(p => p.Address).SingleOrDefaultAsync(p => p.Email == email);

            return user;
        }

        public static async Task<AppUser> FindByEmailFromClaimsPrincipal(this UserManager<AppUser> userManager, ClaimsPrincipal claims)
        {
            var email = claims.Claims?.FirstOrDefault(x => x.Type == ClaimTypes.Email)?.Value;
            // return await _context.CustomerBasket.Include(p => p.Items).FirstOrDefaultAsync(p => p.Id == basketId);
            var user = await userManager.Users.SingleOrDefaultAsync(p => p.Email == email);

            return user;
        }
    }
}