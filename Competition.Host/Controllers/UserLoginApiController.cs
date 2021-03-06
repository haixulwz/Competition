﻿using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Competition.Host.Data;
using IdentityModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace Competition.Host.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserLoginApiController : ControllerBase
    {
        private UserStore _store;
        private readonly IConfiguration _configuration;
        public UserLoginApiController(UserStore userStore,IConfiguration configuration)
        {
            _store = userStore;
            _configuration = configuration;
        }
        [HttpPost("authenticate")]
        public IActionResult Authenticate([FromBody]UserDto userDto)
        {
            var user = _store.FindUser(userDto.UserName, userDto.Password);
            if (user == null) return Unauthorized();
            var authTime = DateTime.UtcNow;
            var expiresAt = authTime.AddSeconds(double.Parse(_configuration["Authentication:JwtBearer:Expiration"]));
            var tokenString = CreateAccessToken(user,expiresAt);
            return Ok(new
            {
                access_token = tokenString,
                token_type = "Bearer",
                profile = new
                {
                    sid = user.Cust_Id,
                    name = user.Cust_Name,
                    auth_time = new DateTimeOffset(authTime).ToUnixTimeSeconds(),
                    expires_at = new DateTimeOffset(expiresAt).ToUnixTimeSeconds()
                }
            });
        }
        private string CreateAccessToken(User user,DateTime  expiresAt)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_configuration["Authentication:JwtBearer:SecurityKey"]);
            var  expires_at = new DateTimeOffset(expiresAt).ToUnixTimeSeconds();
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(JwtClaimTypes.Audience, _configuration["Authentication:JwtBearer:Audience"]),
                    new Claim(JwtClaimTypes.Issuer, _configuration["Authentication:JwtBearer:Issuer"]),
                    new Claim(JwtClaimTypes.Id, user.Cust_Id.ToString()),
                    new Claim(JwtClaimTypes.Name, user.Cust_Name),
                    new Claim(JwtClaimTypes.Expiration, expires_at.ToString())
                    // new Claim(JwtClaimTypes.Email, user.Email),
                    // new Claim(JwtClaimTypes.PhoneNumber, user.PhoneNumber)
                }),
                Expires = expiresAt,
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return   tokenHandler.WriteToken(token);
        }

    }
}