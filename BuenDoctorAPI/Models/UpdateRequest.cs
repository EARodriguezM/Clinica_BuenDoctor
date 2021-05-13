namespace BuenDoctorAPI.Models
{
    public class UpdateRequest
    {
       
        public string DataUserId { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string FirstSurname { get; set; }
        public string SecondSurname { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Mobile { get; set; }
        public byte UserTypeId { get; set; }
        public byte[] ProfilePicture { get; set; }
    
    }
}