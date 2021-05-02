using System.Text;
using System;
using System.Security.Claims;
using System.Threading.Tasks;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using AutoMapper;


using BuenDoctorAPI.Models.Login;
using BuenDoctorAPI.Dtos.Login;
using BuenDoctorAPI.BLL.Login;

namespace BuenDoctorAPI.Controllers.Login
{

    [Route("api/[controller]")]
    [ApiController]
    public class LoginUserController : ControllerBase
    {
        private readonly LoginUserBLL _bll;
        private readonly IConfiguration _config;

        public LoginUserController(LoginUserBLL bll, IConfiguration config)
        {
            _config = config;
            _bll = bll;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDto loginDto)
        {
            var userFromBLL = await _bll.Login(loginDto.UserId, loginDto.Password);
            
            if (userFromBLL == null) return Unauthorized();

            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, userFromBLL.LoginUserId.ToString())
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config.GetSection("AppSettings:Token").Value));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);
            
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddMinutes(30),
                SigningCredentials = credentials

            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);

            return Ok(new {token = tokenHandler.WriteToken(token), username = userFromBLL.LoginUserId});

        }

    }
}