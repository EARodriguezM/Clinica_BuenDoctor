using System.Runtime.CompilerServices;
using System.ComponentModel.DataAnnotations;

namespace BuenDoctorAPI.Models
{
    public class AuthenticateRequest
    {
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }

    }
}