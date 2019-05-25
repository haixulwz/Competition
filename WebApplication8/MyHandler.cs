using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace WebApplication8
{
    public class MyHandler : IAuthenticationHandler, IAuthenticationSignInHandler, IAuthenticationSignOutHandler
    {
        public AuthenticationScheme Scheme { get; private set; }
        protected HttpContext Context { get; private set; }
        public async Task<AuthenticateResult> AuthenticateAsync()
        {
            var cookie = Context.Request.Cookies["mycookie"];
            if (string.IsNullOrEmpty(cookie))
            {
                return AuthenticateResult.NoResult();
            }
            return AuthenticateResult.Success(Deserialize(cookie));
           // throw new NotImplementedException();
        }

        private AuthenticationTicket Deserialize(string cookie)
        { // 创建一个用户身份，注意需要指定AuthenticationType，否则IsAuthenticated将为false。
            Claim claim = new Claim(ClaimTypes.Role, "a");

            var claimIdentity = new ClaimsIdentity(Scheme.Name);

            // 添加几个Claim
            claimIdentity.AddClaim(new Claim(ClaimTypes.Name, cookie));
            var principal = new ClaimsPrincipal(claimIdentity);
            return new AuthenticationTicket(principal, Scheme.Name);
        }

        public Task ChallengeAsync(AuthenticationProperties properties)
        {
            Context.Response.Redirect("/login");
            return Task.CompletedTask;
           // throw new NotImplementedException();
        }

        public Task ForbidAsync(AuthenticationProperties properties)
        {
            Context.Response.StatusCode = 403;
            return Task.CompletedTask;
           // throw new NotImplementedException();
        }

        public Task InitializeAsync(AuthenticationScheme scheme, HttpContext context)
        {
            Scheme = scheme;
            Context = context;
            return Task.CompletedTask;
           // return Task.CompletedTask;
           // throw new NotImplementedException();
        }

        public Task SignInAsync(ClaimsPrincipal user, AuthenticationProperties properties)
        {
            var ticket = new AuthenticationTicket(user, properties, Scheme.Name);
             Context.Response.Cookies.Append("myCookie", Serialize(ticket));
            return Task.CompletedTask;
            //throw new NotImplementedException();
        }

        private string Serialize(AuthenticationTicket ticket)
        {
            throw new NotImplementedException();
        }

        public Task SignOutAsync(AuthenticationProperties properties)
        {
            throw new NotImplementedException();
        }
    }
}
