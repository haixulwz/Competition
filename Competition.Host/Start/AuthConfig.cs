using IdentityModel;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Competition.Host.Start
{
    public static class AuthConfig
    {
        public static void Configure(IServiceCollection services, IConfiguration configuration)
        {
            var authenticationBuilder = services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            });

            if (bool.Parse(configuration["Authentication:JwtBearer:IsEnabled"]))
            {
                authenticationBuilder.AddJwtBearer(options =>
                {
                   
                    options.TokenValidationParameters = new TokenValidationParameters
                {
                    NameClaimType = JwtClaimTypes.Name,
                    RoleClaimType = JwtClaimTypes.Role,

                        ValidateIssuer = true,
                        ValidIssuer = configuration["Authentication:JwtBearer:Issuer"],

                        // Validate the JWT Audience (aud) claim
                        ValidateAudience = true,
                        ValidAudience = configuration["Authentication:JwtBearer:Audience"],
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(configuration["Authentication:JwtBearer:SecurityKey"]))
                };

                    options.Events = new JwtBearerEvents()
                    {
                        OnMessageReceived = context =>
                        {
                            context.Token = context.Request.Query["access_token"];
                            return Task.CompletedTask;
                        }
                    };
                });
            }
        }

        /* This method is needed to authorize SignalR javascript client.
         * SignalR can not send authorization header. So, we are getting it from query string as an encrypted text. */
        private static Task QueryStringTokenResolver(MessageReceivedContext context)
        {
            if (!context.HttpContext.Request.Path.HasValue ||
                !context.HttpContext.Request.Path.Value.StartsWith("/signalr"))
            {
                //We are just looking for signalr clients
                return Task.CompletedTask;
            }

            var qsAuthToken = context.HttpContext.Request.Query["access_token"].FirstOrDefault();
            if (qsAuthToken == null)
            {
                //Cookie value does not matches to querystring value
                return Task.CompletedTask;
            }

            //Set auth token from cookie
            context.Token = qsAuthToken; //SimpleStringCipher.Instance.Decrypt(qsAuthToken, AppConsts.DefaultPassPhrase);
            return Task.CompletedTask;
        }

        private static Task OnlyOneUserToken(TokenValidatedContext context)
        {

            var bSuccessed = ((System.IdentityModel.Tokens.Jwt.JwtSecurityToken)context.SecurityToken).RawData;
            // context.SecurityToken

            return Task.CompletedTask;
        }
    }
}
