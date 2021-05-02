using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

using BuenDoctorAPI.Models.Data;
using BuenDoctorAPI.Repositories.Login;

namespace BuenDoctorAPI.Repositories.Data
{
    public class DataUserRepository
    {
        private readonly BuenDoctorDataContext _context;

        public DataUserRepository(BuenDoctorDataContext context)
        {
            _context = context;
        }

        public async Task<DataUser> Register(DataUser user)
        {
            await _context.DataUsers.AddAsync(user);
            await _context.SaveChangesAsync();

            return user;
        }
        public async Task<bool> IdExists(string userId)
        {
            if (await _context.DataUsers.AnyAsync(x => x.DataUserId == userId))
                return true;
            return false;
        }

    }
}