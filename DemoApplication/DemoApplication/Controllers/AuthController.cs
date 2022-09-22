using DemoApplication.Data;
using DemoApplication.Interface;
using DemoApplication.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace DemoApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuth _loginMatch;
        private readonly IConfiguration _configuration;

        //private readonly DemoDbContext db;
        //private readonly Jwt jwt;
        public AuthController(IAuth LoginMatch,DemoDbContext db,IConfiguration configuration)
        {
            this._loginMatch = LoginMatch;
            _configuration = configuration;
        }

        [HttpPost("login")]
        public IActionResult Login(LoginModel loginModel)
        {
            //var _user = db.LoginMatches.FirstOrDefaultAsync(s => s.Email == loginModel.Email && s.Password == loginModel.Password);
            var _user = _loginMatch.Authenticate(loginModel.Email,loginModel.Password);
            
            if(_user == null)
            {
                return Unauthorized();
            }
                       
            var clamis = new[]
            {
                new Claim(ClaimTypes.Email, _user.Email),
                new Claim(ClaimTypes.Role, _user.type)
            };  
            var tokenKey = new JwtSecurityToken
            (
                issuer: _configuration.GetSection("Jwt:Issuer").Value,
                audience: _configuration.GetSection("Jwt:Audience").Value,
                claims: clamis,
                expires: DateTime.UtcNow.AddDays(5),
                signingCredentials: new SigningCredentials(
                    new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration.GetSection("Jwt:Key").Value)), SecurityAlgorithms.HmacSha256)

             );

            var tokenString = new JwtSecurityTokenHandler().WriteToken(tokenKey);
            return Ok(tokenString);            
        }
        
    }
}
