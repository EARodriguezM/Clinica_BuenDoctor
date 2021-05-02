using System.ComponentModel.DataAnnotations;

namespace BuenDoctorAPI.Dtos.Data
{
    public class RegisterUserDto
    {
        [Required]
        [StringLength(10, MinimumLength = 6, ErrorMessage = "ID must be at least 6 characters")]
        public string UserId { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Name must be at least 2 characters")]
        public string FirstName { get; set; }

        [StringLength(50, MinimumLength = 2, ErrorMessage = "Second name must be at least 2 characters")]
        public string SecondName { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "First surname must be at least 2 characters")]
        public string FirstSurname { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Second surname must be at least 2 characters")]
        public string SecondSurname { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 8, ErrorMessage = "Name must be at least 8 characters")]
        public string Password { get; set; }

        [StringLength(50, MinimumLength = 8, ErrorMessage = "Name must be at least 8 characters")]
        public string Email { get; set; }

        [StringLength(50, MinimumLength = 10, ErrorMessage = "Name must be at least 10 characters")]
        public string Phone { get; set; }

        [Required]
        public byte UserTypeId { get; set; }
        
        public byte[] ProfilePicture { get; set; }
        public bool? Status { get; set; }
    }
}