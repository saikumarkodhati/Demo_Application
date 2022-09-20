using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DigitalBook.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.IdentityModel.Tokens.Jwt;

namespace DigitalBook.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        BookDBContext db = new BookDBContext();
        private IConfiguration _config;

        public LoginController(IConfiguration config)
        {
            _config = config;
        }

        [HttpPost]
        [Route("login-user")]
        public IActionResult Login(LogIn loginss)
        {
            IActionResult response = Unauthorized();
            var user = AuthenticateUser(loginss, false);
            if (user != null)
            {
                var tokenString = GenerateToken(user);
                response = Ok(new { token = tokenString });
            }
            return response;
        }
        private LogIn AuthenticateUser(LogIn login, bool IsRegister)
        {
            if (IsRegister)
            {
                db.LogIns.Add(login);
                db.SaveChanges();
                return login;
            }
            else
            {
                if (db.LogIns.Any(x => x.UserName == login.UserName && x.Password == login.Password))
                {
                    return db.LogIns.Where(x => x.UserName == login.UserName && x.Password == login.Password).FirstOrDefault();
                }
                else
                {
                    return null;
                }
            }
        }
        private string GenerateToken(LogIn login)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(_config["jwt:Issuer"],
                _config["jwt:Audience"],
                null,
                expires: DateTime.Now.AddMinutes(120),
                signingCredentials: credentials);
            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        [HttpPost]
        [Route("register-user")]
        public IActionResult Register(LogIn login)
        {
            IActionResult response = Unauthorized();
            var user = AuthenticateUser(login, true);
            if (user != null)
            {
                var tokenString = GenerateToken(user);
                response = Ok(new { token = tokenString });
            }
            return response;
        }
    }
}
