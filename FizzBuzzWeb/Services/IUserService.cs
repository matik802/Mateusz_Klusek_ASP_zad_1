using Microsoft.AspNetCore.Identity;

namespace FizzBuzzWeb.Services
{
    public interface IUserService
    {
        public IdentityUser GetUser(string userId);
    }
}
