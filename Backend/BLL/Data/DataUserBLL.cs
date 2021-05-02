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
using BuenDoctorAPI.Repositories.Data;
using BuenDoctorAPI.BLL.Login;

namespace BuenDoctorAPI.BLL.Data
{
    public class DataUserBLL
    {

        private readonly DataUserRepository _repository;
        private readonly LoginUserBLL _LoginBll;
 
        private readonly IMapper _mapper;

        public DataUserBLL(IMapper mapper, DataUserRepository repository, LoginUserBLL loginBll)
        {
            _LoginBll = loginBll;
            _mapper = mapper;
            _repository = repository;
        }
        public async Task<DataUser> Register(RegisterUserDto registerDto)
        {
            

            var loginCreated = _LoginBll.CreateLoginEntity(registerDto.UserId, registerDto.Password);
            
            var userToCreate = _mapper.Map<DataUser>(registerDto);

            userToCreate.PasswordHash = loginCreated.PasswordHash;
            userToCreate.PasswordSalt = loginCreated.PasswordSalt;

            var createdUser = await _repository.Register(userToCreate);
            _LoginBll.Register(loginCreated);

            return createdUser;
        }

        public async Task<bool> IdExists(string userId)
        {
            return await _repository.IdExists(userId);
        }
    }
}