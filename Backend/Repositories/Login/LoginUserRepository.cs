using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

using BuenDoctorAPI.Models.Login;

namespace BuenDoctorAPI.Repositories.Login
{
    public class LoginUserRepository:ILoginUserRepository
    {
        private readonly BuenDoctorLoginContext _context;

        public LoginUserRepository(BuenDoctorLoginContext context)
        {
            _context = context;
        }

        public async Task<LoginUser> Login(string userId, string password)
        {
            var login = await _context.LoginUsers.FirstOrDefaultAsync(x => x.LoginUserId == userId);
            
            if (login == null) return null;

            if (!VerifyPasswordHash(password, login.PasswordHash, login.PasswordSalt)) return null;

            return login;
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

        public async Task<bool> Register(LoginUser login)
        {
            await _context.LoginUsers.AddAsync(login);
            await _context.SaveChangesAsync();

            return true;
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

        public async Task<bool> UserExists(string userId)
        {
            if (await _context.LoginUsers.AnyAsync(x => x.LoginUserId == userId)) return true;

            return false;
        }
    
    }
}