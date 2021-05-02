using System.Runtime.CompilerServices;
using System.ComponentModel.DataAnnotations;

namespace BuenDoctorAPI.Dtos.Login
{
    public class LoginDto
    {
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }

    }
}