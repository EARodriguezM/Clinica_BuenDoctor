using BuenDoctorAPI.Entities;

namespace BuenDoctorAPI.Models
{
    public class AuthenticateResponse
    {
        public string DataUserId { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string FirstSurname { get; set; }
        public string SecondSurname { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public byte[] ProfilePicture { get; set; }

        public string Token { get; set; }

        public AuthenticateResponse(DataUser dataUser, string token)
        {
            DataUserId = dataUser.DataUserId;
            FirstName = dataUser.FirstName;
            SecondName = dataUser.SecondName;
            FirstSurname = dataUser.FirstSurname;
            SecondSurname = dataUser.SecondSurname;
            Email = dataUser.Email;
            Phone = dataUser.Phone;
            ProfilePicture = dataUser.ProfilePicture;

            Token = token;
        }
 
    }
}