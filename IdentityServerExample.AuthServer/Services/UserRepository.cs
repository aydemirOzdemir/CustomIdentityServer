using IdentityServerExample.AuthServer.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using static IdentityServer4.Models.IdentityResources;

namespace IdentityServerExample.AuthServer.Services;

public class UserRepository : IUserRepository
{
    private readonly CustomDbContext context;

    public UserRepository(CustomDbContext context)
    {
        this.context = context;
    }
    public async Task<CustomUser> FindByEmailAsync(string email)
    {
       return await context.CustomUsers.FirstOrDefaultAsync(x => x.Email == email);
    }

    public async Task<CustomUser> FindByIdAsync(int id)
    {
        return await context.CustomUsers.FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<bool> ValidateAsync(string email, string password)
    {
       return await context.CustomUsers.AnyAsync(x=>x.Email==email &&x.Password==password);
    }
}
