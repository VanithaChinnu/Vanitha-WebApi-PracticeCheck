using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace TruYumWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase {
        [HttpGet]
        public ActionResult GetToken(string key, int userId) {
            return Ok(GenerateJWT(key, userId));
        }
        public string GenerateJWT(string key, int userId) {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var claims = new List<Claim>();
            if (userId == -1) {               
            }
            else if (userId == 1) {
                claims.Add(new Claim(ClaimTypes.Role, "Admin"));
            }
            else {
                claims.Add(new Claim(ClaimTypes.Role, "Customer"));
            }
            var token = new JwtSecurityToken(
                claims: claims,
                issuer: "https://www.snrao.com",
                audience: "https://www.snrao.com",
                expires: DateTime.Now.AddHours(3),
                signingCredentials: credentials
            );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }

    }
}
