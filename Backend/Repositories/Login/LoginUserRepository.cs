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

            return login;
        }

        public async Task<bool> Register(LoginUser login)
        {
            await _context.LoginUsers.AddAsync(login);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> UserExists(string userId)
        {
            if (await _context.LoginUsers.AnyAsync(x => x.LoginUserId == userId)) return true;

            return false;
        }
    
    }
}