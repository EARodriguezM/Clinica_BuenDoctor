using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

using Microsoft.AspNetCore.Authorization;

using BuenDoctorAPI.Services;
using BuenDoctorAPI.Models;
using BuenDoctorAPI.Entities;
using BuenDoctorAPI.Helpers;

namespace BuenDoctorAPI.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class DataUserController : ControllerBase
    {
        private readonly IDataUserService _dataUserService;

        public DataUserController(IDataUserService dataUserService)
        {
            _dataUserService = dataUserService;
        }

        [AllowAnonymous]
        [HttpPost("authenticate")]
        public async Task<IActionResult> Authenticate([FromForm]AuthenticateRequest authenticateRequest)
        {
            var user = await _dataUserService.Authenticate(authenticateRequest.Email, authenticateRequest.Password);

            if (user == null) 
                return BadRequest(new {message = "Email or password is incorrect"});

            return Ok(user);
        }
        
        [Authorize(Roles = "1")]
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromForm]RegisterRequest registerRequest)
        {
            try
            {
                await _dataUserService.Register(registerRequest);
                return Ok();
            }
            catch (AppException ex)
            {
                return BadRequest(new {message = ex.Message });
            }
        }

        [Authorize(Roles = "1")]
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var users =  await _dataUserService.GetAll();
            return Ok(users);
        }

        [HttpGet("{dataUserId}")]
        public IActionResult GetById(string dataUserId)
        {
            // only allow admins to access other user records
            var currentUserId = (User.Identity.Name).ToString();
            
            if (dataUserId != currentUserId || !User.IsInRole("1"))
                return Forbid();

            var user =  _dataUserService.GetById(dataUserId);

            if (user == null)
                return NotFound();

            return Ok(user);
        }

        [HttpPut("{dataUserId}")]
        public IActionResult Update(string dataUserId, [FromForm]UpdateRequest updateRequest)
        {
            
            // only allow admins to access other user records
            var currentUserId = (User.Identity.Name).ToString();
            
            if (dataUserId != currentUserId || !User.IsInRole("1"))
                return Forbid();

            try
            {
                // update user 
                _dataUserService.Update(updateRequest, dataUserId, updateRequest.Password);
                return Ok();
            }
            catch (AppException ex)
            {
                // return error message if there was an exception
                return BadRequest(new { message = ex.Message });
            }
        }
    }
}