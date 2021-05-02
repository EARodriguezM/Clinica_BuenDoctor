using System.Threading.Tasks;
using BuenDoctorAPI.Models.Login;

namespace BuenDoctorAPI.Repositories.Login
{
    public interface ILoginUserRepository
    {
        Task<LoginUser> Login(string userId, string password);
        Task<bool> Register(LoginUser login);
        Task<bool> UserExists(string userId);
    }
}