using IdentityServerExample.AuthServer.Models;

namespace IdentityServerExample.AuthServer.Services;

public interface IUserRepository
{
   Task< bool> ValidateAsync(string email, string password);
    Task<CustomUser> FindByIdAsync(int id);
   Task <CustomUser> FindByEmailAsync(string email);
}
