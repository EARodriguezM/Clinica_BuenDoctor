using System.Text;
using System;
using System.Security.Claims;
using System.Threading.Tasks;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using AutoMapper;

using BuenDoctorAPI.Models.Data;
using BuenDoctorAPI.Dtos.Data;
using BuenDoctorAPI.BLL.Data;

namespace BuenDoctorAPI.Controllers.Data
{
    [Route("api/[controller]")]
    [ApiController]
    public class DataUserController : ControllerBase
    {

        private readonly DataUserBLL _bll;
        private readonly IMapper _mapper;

        public DataUserController(IMapper mapper, DataUserBLL bll)
        {
            _mapper = mapper;
            _bll = bll;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterUserDto registerDto)
        {
            registerDto.Email = registerDto.Email.ToLower();
            
            if (await _bll.IdExists(registerDto.UserId))
                return BadRequest("Id already exists");

            DataUser createdUser;
            try
            {
                createdUser = await _bll.Register(registerDto);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex);

            }

            return StatusCode(201, new { id = createdUser.DataUserId, Name = createdUser.FirstName + " " + createdUser.FirstSurname });
        }
        
    }
}