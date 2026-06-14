using LibraryProject.Interface.TokenInterface;
using LibraryProject.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace LibraryProject.Service
{
    public class TokenService : IToken
    {
        public TokenService(UserManager<Appuser> userManager, IConfiguration configuration) 
        { 
            _userManager = userManager;
            _configuration = configuration;
        }

        private readonly UserManager<Appuser> _userManager;
        private readonly IConfiguration _configuration;

        public async Task<string>CreateTokenAsync(Appuser appuser)
        { 
            var roles = await _userManager.GetRolesAsync(appuser);
            var role=roles.FirstOrDefault()??"user";// for now
            var claim = new List<Claim>
            {
               
                new Claim(ClaimTypes.NameIdentifier,appuser.Id),
                new Claim(ClaimTypes.Email,appuser.Email),
                new Claim(ClaimTypes.Role,role)
            };
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var Sc = new SigningCredentials(key,SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(
                claims:claim,
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                expires: DateTime.UtcNow.AddHours(1),
                signingCredentials:Sc
                );
            return new JwtSecurityTokenHandler().WriteToken(token);
            
            
        }
    }
}
