using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

using Microsoft.EntityFrameworkCore;


using AutoMapper;

using BuenDoctorAPI.Entities;
using BuenDoctorAPI.Helpers;
using BuenDoctorAPI.Models;



namespace BuenDoctorAPI.Services
{

    public interface IDataUserService
    {
        Task<AuthenticateResponse> Authenticate(string dataUserId, string password);
        Task<DataUser> Register(RegisterRequest registerRequest);
        Task<IEnumerable<DataUser>> GetAll();
        Task<DataUser> GetById(string dataUserId);
        Task Update(UpdateRequest updateRequest, string password = null);
        Task Delete (string dataUserId);
    }

    public class DataUserService : IDataUserService
    {
        private readonly BuenDoctorDataContext _context;
        private readonly IMapper _mapper;
        private readonly AppSettings _appSettings;

        public DataUserService(BuenDoctorDataContext context, IMapper mapper, IOptions<AppSettings> appSettings)
        {
            _context = context;
            _mapper = mapper;
            _appSettings = appSettings.Value;
        }

        public async Task<AuthenticateResponse> Authenticate(string dataUserId, string password)
        {
            var user = await _context.DataUsers.SingleOrDefaultAsync(x => x.DataUserId == dataUserId);

            if (user == null)
                return null;
            
            if (!VerifyPasswordHash(password, user.PasswordHash, user.PasswordSalt))
                return null;

            var authenticateResponse = _mapper.Map<AuthenticateResponse>(user.WithoutPassword());
            authenticateResponse.Token = GenerateToken(user);

            return authenticateResponse;

        }
        public async Task<DataUser> Register(RegisterRequest registerRequest)
        {
            var dataUser = _mapper.Map<DataUser>(registerRequest);
            var password = registerRequest.Password;

            if (string.IsNullOrWhiteSpace(password))
                throw new AppException("Password is required");

            if (await _context.DataUsers.AnyAsync(x => x.DataUserId == dataUser.DataUserId))
                throw new AppException("Id \"" + dataUser.DataUserId + "\" is regiostered");

            byte[] passwordHash, passwordSalt;
            CreatePasswordHash(password, out passwordHash, out passwordSalt);

            dataUser.PasswordHash = passwordHash;
            dataUser.PasswordSalt = passwordSalt;

            await _context.DataUsers.AddAsync(dataUser);
            await _context.SaveChangesAsync();

            return dataUser.WithoutPassword();
        }
        public async Task<IEnumerable<DataUser>> GetAll()
        {
            var dataUsers =  await _context.DataUsers.ToListAsync();
            return dataUsers.WithoutPasswords();
        }
        public async Task<DataUser> GetById(string dataUserId)
        {
            var userFinded = await _context.DataUsers.FindAsync(dataUserId);
            return userFinded.WithoutPassword();
        }
        public async Task Update(UpdateRequest updateRequest, string password = null)
        {

            var dataUser = _mapper.Map<DataUser>(updateRequest);
            
            var user = _context.DataUsers.Find(dataUser.DataUserId);

            if (user == null)
                throw new AppException("User not found");

            // update email if it has changed
            if (!string.IsNullOrWhiteSpace(dataUser.Email) && dataUser.Email != user.Email)
            {
                // throw error if the new email is already taken
                if (_context.DataUsers.Any(x => x.Email == dataUser.Email))
                    throw new AppException("Username " + dataUser.Email + " is already taken");

                user.Email = dataUser.Email;
            }

            // update phone if it has changed
            if (!string.IsNullOrWhiteSpace(dataUser.Phone) && dataUser.Phone != user.Phone)
            {
                // throw error if the new phone is already taken
                if (_context.DataUsers.Any(x => x.Phone == dataUser.Phone))
                    throw new AppException("Username " + dataUser.Phone + " is already taken");

                user.Phone = dataUser.Phone;
            }

            if (!string.IsNullOrWhiteSpace(dataUser.UserTypeId.ToString()) && dataUser.UserTypeId != user.UserTypeId)
            {
                user.UserTypeId = dataUser.UserTypeId;
            }

            // update user properties if provided
            if (!string.IsNullOrWhiteSpace(dataUser.FirstName))
                user.FirstName = dataUser.FirstName;
            if (!string.IsNullOrWhiteSpace(dataUser.SecondName))
                user.SecondName = dataUser.SecondName;
            if (!string.IsNullOrWhiteSpace(dataUser.FirstSurname))
                user.FirstSurname = dataUser.FirstSurname;
            if (!string.IsNullOrWhiteSpace(dataUser.SecondSurname))
                user.SecondSurname = dataUser.SecondSurname;

            // update password if provided
            if (!string.IsNullOrWhiteSpace(password))
            {
                byte[] passwordHash, passwordSalt;
                CreatePasswordHash(password, out passwordHash, out passwordSalt);

                user.PasswordHash = passwordHash;
                user.PasswordSalt = passwordSalt;
            }

            _context.DataUsers.Update(user);
            await _context.SaveChangesAsync();
        }
        public async Task Delete (string dataUserId)
        {
            var user = await _context.DataUsers.FindAsync(dataUserId);
            if (user != null)
            {
                _context.DataUsers.Remove(user);
                await _context.SaveChangesAsync();
            }
        }




        // private helper methods


        private string GenerateToken(DataUser dataUser)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[] 
                {
                    new Claim(ClaimTypes.Name, dataUser.DataUserId.ToString()),
                    new Claim(ClaimTypes.Role, dataUser.UserTypeId.ToString())
                }),
                Expires = DateTime.UtcNow.AddMinutes(30),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
 

        private static void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            if (password == null) throw new ArgumentNullException("password");
            if (string.IsNullOrWhiteSpace(password)) throw new ArgumentException("Value cannot be empty or whitespace only string.", "password");

            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }

        private static bool VerifyPasswordHash(string password, byte[] storedHash, byte[] storedSalt)
        {
            if (password == null) throw new ArgumentNullException("password");
            if (string.IsNullOrWhiteSpace(password)) throw new ArgumentException("Value cannot be empty or whitespace only string.", "password");
            if (storedHash.Length != 64) throw new ArgumentException("Invalid length of password hash (64 bytes expected).", "passwordHash");
            if (storedSalt.Length != 128) throw new ArgumentException("Invalid length of password salt (128 bytes expected).", "passwordHash");

            using (var hmac = new System.Security.Cryptography.HMACSHA512(storedSalt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                for (int i = 0; i < computedHash.Length; i++)
                {
                    if (computedHash[i] != storedHash[i]) return false;
                }
            }

            return true;
        }
        
    }
}