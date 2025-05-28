using Microsoft.AspNetCore.Components.Authorization;
using System.Security.Claims;

namespace ModHub.WEB.Auth
{
    public class AuthenticationProvider : AuthenticationStateProvider
    {
        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            await Task.Delay(5000);
            var oapUser = new ClaimsIdentity(new List<Claim>
            {
                new Claim("FirstName", "Sebastian"),
                new Claim("LastName", "Ramirez"),
                new Claim(ClaimTypes.Name, "159sebastian.ramirez@gmail.com"),
                new Claim(ClaimTypes.Role, "Admin")
            },
            authenticationType: "test");

            var anonimous = new ClaimsIdentity();
            return await Task.FromResult(new AuthenticationState(new ClaimsPrincipal(oapUser)));
        }
    }
}
