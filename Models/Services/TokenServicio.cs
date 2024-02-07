using DoctorApp.Interfaces;
using DoctorApp.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Models.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace DoctorApp.Services
{
    public class TokenServicio : ITokenServicio
    {
        private readonly UserManager<UsuarioAplicacionModel> _userManager;
        private readonly SymmetricSecurityKey _key;

        public TokenServicio(IConfiguration config, UserManager<UsuarioAplicacionModel> userManager)
        {
            _key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["TokenKey"]));
            _userManager = userManager;
        }

        public async Task<string> CrearToken(UsuarioAplicacionModel usuario)
        {
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.NameId, usuario.UserName),
            };

            var roles = await _userManager.GetRolesAsync(usuario);
            claims.AddRange(roles.Select(rol => new Claim(ClaimTypes.Role, rol)));

            var creds = new SigningCredentials(_key, SecurityAlgorithms.HmacSha256Signature);
            var tokenDescription = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(7),
                SigningCredentials = creds
            };
            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescription);
            return tokenHandler.WriteToken(token);
        }
    }
}
