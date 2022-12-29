using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using TeamChat.Models.DTO;
using TeamChat.Models.Interfaces.Authentication;

namespace TeamChat.Services.Authentication;

public class CookieUserAuthService: IUserAuthService
{
    private IHttpContextAccessor contextAccessor;


    public CookieUserAuthService(IHttpContextAccessor contextAccessor)
    {
        this.contextAccessor = contextAccessor;
    }

    public async Task SignIn(User user)
    {

        var identity = new ClaimsIdentity(this.GetUserClaims(user), CookieAuthenticationDefaults.AuthenticationScheme);
        var principal = new ClaimsPrincipal(identity);

        await contextAccessor.HttpContext?.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal)!;
    }

    public async Task SignOut()
    {
        await contextAccessor.HttpContext?.SignOutAsync()!;
    }

    private IEnumerable<Claim> GetUserClaims(User user)
    {
        List<Claim> claims = new List<Claim>();

        claims.Add(new Claim(ClaimTypes.NameIdentifier, user.UserId.ToString()));
        claims.Add(new Claim(ClaimTypes.Name, user.UserName));
       
        return claims;
    }
    
}