using System;
using System.Collections.Generic;

#nullable disable

namespace BuenDoctorAPI.Models.Data
{
    public partial class DataUser
    {
        public DataUser()
        {
            Appointments = new HashSet<Appointment>();
            RDataUserUserTypes = new HashSet<RDataUserUserType>();
        }

        public string DataUserId { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string FirstSurname { get; set; }
        public string SecondSurname { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public byte[] ProfilePicture { get; set; }
        public bool? Status { get; set; }

        public virtual ICollection<Appointment> Appointments { get; set; }
        public virtual ICollection<RDataUserUserType> RDataUserUserTypes { get; set; }
    }
}
