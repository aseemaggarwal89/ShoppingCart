using System.Linq;
using System.Threading.Tasks;
using Core.Entities.Identity;
using Microsoft.AspNetCore.Identity;

namespace Infrastructure.Identity
{
    public class AppIdentityDbContextSeed
    {
        public static async Task SeedUserAsync(UserManager<AppUser> userManager)
        {
            if (!userManager.Users.Any())
            {
                var user = new AppUser {
                    DisplayName = "Aseem",
                    Email = "aseemaggarwal2009@gmail.com",
                    UserName = "aseemaggarwal2009@gmail.com",
                    Address = new Address {
                        FirstName = "Aseem",
                        LastName = "Aggarwal",
                        Street = "GTB Enclave",
                        City = "Muktsar",
                        State = "Punjab",
                        ZipCode = "152026"
                    }
                };

                await userManager.CreateAsync(user, "Pa$$w0rd");
            }
        }
    }
}