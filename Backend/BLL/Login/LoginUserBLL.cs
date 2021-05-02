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
using BuenDoctorAPI.Repositories.Login;

namespace BuenDoctorAPI.BLL.Login
{
    public class LoginUserBLL
    {
        private readonly ILoginUserRepository _repository;

        public LoginUserBLL(ILoginUserRepository repository)
        {
            _repository = repository;
        }

        public async Task<LoginUser> Login(string userId, string password)
        {
            var userFromRepo = await _repository.Login(userId, password);

            if (!VerifyPasswordHash(password, userFromRepo.PasswordHash, userFromRepo.PasswordSalt)) return null;

            return userFromRepo;
        }

        //This method will be called by Register in Data Context
        //The function is create a Hash and Salt, and save user in the login database.
        public LoginUser CreateLoginEntity(string userId, string password)
        {
            LoginUser login = new LoginUser();
            login.LoginUserId = userId;
            
            byte[] passwordHash, salt;
            CreatePasswordHash(password, out passwordHash, out salt);

            login.PasswordHash = passwordHash;
            login.PasswordSalt = salt;

            return login;
        }

        public async Task Register(LoginUser loginUser)
        {
            await _repository.Register(loginUser);
        }

        private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] salt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512(salt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));

                for (var i = 0; i < computedHash.Length; i++)
                {
                    if (computedHash[i] != passwordHash[i]) return false;
                }
            }

            return true;
        }

        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] salt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                salt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }  
    }
}