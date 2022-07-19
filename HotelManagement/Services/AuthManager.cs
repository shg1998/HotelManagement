using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using HotelManagement.Data;
using HotelManagement.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace HotelManagement.Services
{
    public class AuthManager : IAuthManager
    {
        private readonly UserManager<ApiUser> _userManager;
        private readonly IConfiguration _configuration;
        private  ApiUser _apiUser;

        public AuthManager(UserManager<ApiUser> userManager, IConfiguration configuration)
        {
            _userManager = userManager;
            _configuration = configuration;
        }

        public async Task<bool> ValidateUser(LoginDTO loginDto)
        {
            _apiUser = await _userManager.FindByNameAsync(loginDto.Email);
            return (_apiUser != null && await _userManager.CheckPasswordAsync(_apiUser, loginDto.Password));
        }

        public async Task<string> CreateToken()
        {
            var signingCredentials = GetSigningCredentials();
            var claims = await GetClaims();
            var tokenOptions = GenerateTokenOptions(signingCredentials, claims);
            return new JwtSecurityTokenHandler().WriteToken(tokenOptions);
        }

        private JwtSecurityToken GenerateTokenOptions(SigningCredentials signingCredentials, List<Claim> claims)
        {
            var jwtSettings = _configuration.GetSection("Jwt");
            var expiration = DateTime.Now.AddMinutes(15);
            var token = new JwtSecurityToken(
                issuer: jwtSettings.GetSection("issuer").Value,
                claims:claims,
                expires: expiration,
                signingCredentials:signingCredentials
            );
            return token;
        }

        private async Task<List<Claim>> GetClaims()
        {
            var claims = new List<Claim>
            {
                new(ClaimTypes.Name,_apiUser.UserName)
            };
            var roles = await _userManager.GetRolesAsync(_apiUser);
            claims.AddRange(roles.Select(role => new Claim(ClaimTypes.Role, role)));
            return claims;
        }

        private SigningCredentials GetSigningCredentials()
        {
            var jwtSettings = _configuration.GetSection("Jwt");
            var key = jwtSettings.GetSection("Key").Value;
            var secret = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
            return new SigningCredentials(secret, SecurityAlgorithms.HmacSha256);
        }
    }
}
