using IdentityServer4.Extensions;
using IdentityServer4.Models;
using IdentityServer4.Services;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace IdentityServerExample.AuthServer.Services;

public class CustomProfileService : IProfileService
{
    private readonly IUserRepository userRepository;

    public CustomProfileService(IUserRepository userRepository)
    {
        this.userRepository = userRepository;
    }
    public async Task GetProfileDataAsync(ProfileDataRequestContext context)
    {
        var userId = context.Subject.GetSubjectId();
        var user = await userRepository.FindByIdAsync(int.Parse(userId));
        var claims=new List<Claim>()
        {
           
            new Claim(JwtRegisteredClaimNames.Email,user.Email),
            new Claim("name",user.Name),
            new Claim("city",user.City),
        };
        if (user.Id == 1)  
            claims.Add(new Claim("role", "Admin"));
        
        else
            claims.Add(new Claim("role", "Customer"));
        context.AddRequestedClaims(claims);
       // context.IssuedClaims = claims; tüm claimleri jwtinin içinde de veriri uygun değil

    }

    public async Task IsActiveAsync(IsActiveContext context)
    {
        var userId=context.Subject.GetSubjectId();
        var user = await userRepository.FindByIdAsync(int.Parse(userId));

        context.IsActive = user != null ?true : false;
    }
}
