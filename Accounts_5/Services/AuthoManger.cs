using Accounts_5.Data;
using Accounts_5.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Accounts_5.Services
{
    public class AuthoManger : IAuthoManger
    {
        private readonly UserManager<Person> _userManager;
        private readonly IConfiguration _configuration;
        private Person _user;

        public AuthoManger(UserManager<Person> userManager, IConfiguration configuration)
        {
            _userManager = userManager;
            _configuration = configuration;
        }

        public async Task<string> CreatToken()
        {
            var signingCredentials = GetSingingCredentials();
            var claims = await GetClaims();
            var tokenOptions = GenerateTokenOptions(signingCredentials, claims);
            return new JwtSecurityTokenHandler().WriteToken(tokenOptions);
        }

        private JwtSecurityToken GenerateTokenOptions(SigningCredentials signingCredentials, List<Claim> claims)
        {
            var jwtSettings = _configuration.GetSection("jwt");
            var expiration = DateTime.Now.AddMinutes(Convert.ToDouble(jwtSettings.GetSection("lifetime").Value));
            var token = new JwtSecurityToken(
                issuer: jwtSettings.GetSection("Issuer").Value,
                claims: claims,
                expires: expiration,
                signingCredentials: signingCredentials
                );
            return token;
        }

        private async Task<List<Claim>> GetClaims()
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name,_user.UserName)
            };
            var roles = await _userManager.GetRolesAsync(_user);
            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }
            return claims;
        }

        private SigningCredentials GetSingingCredentials()
        {
            var key = Environment.GetEnvironmentVariable("KEY");
            var secret = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
            return new SigningCredentials(secret, SecurityAlgorithms.HmacSha256);
        }
        public async Task<bool> ValidateUser(LoginPersonDTO personDTO)
        {
            _user = await _userManager.FindByIdAsync(personDTO.id);
            var validPassword = await _userManager.CheckPasswordAsync(_user, personDTO.Password);
            return (_user != null && validPassword);
        }

        public async Task<string> CreateRefreshToken()
        {
            try
            {
                await _userManager.RemoveAuthenticationTokenAsync(_user, "CovidApi", "RefreshToken");
                var newRefreshToken = await _userManager.GenerateUserTokenAsync(_user, "CovidApi", "RefreshToken");
                var result = await _userManager.SetAuthenticationTokenAsync(_user, "CovidApi", "RefreshToken", newRefreshToken);
                return newRefreshToken;
            }
            catch (Exception ex)
            {

                throw;
            }
           
        }

        public async Task<TokenRequest> VerifyRefreshToken(TokenRequest request)
        {
            var jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
            var tokenContent = jwtSecurityTokenHandler.ReadJwtToken(request.Token);
            var username = tokenContent.Claims.ToList().FirstOrDefault(q => q.Type == ClaimTypes.Name)?.Value;
            _user = await _userManager.FindByNameAsync(username);
            try
            {
                var isValid = await _userManager.VerifyUserTokenAsync(_user, "CovidApi", "RefreshToken", request.RefreshToken);
                if (isValid)
                {
                    return new TokenRequest { Token = await CreatToken(), RefreshToken = await CreateRefreshToken(),rand= request.rand };
                }
                await _userManager.UpdateSecurityStampAsync(_user);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return null;
        }
    }
}
