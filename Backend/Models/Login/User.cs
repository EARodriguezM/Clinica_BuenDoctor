using System;
using System.Collections.Generic;

#nullable disable

namespace BuenDoctorAPI.Models.Login
{
    public partial class User
    {
        public string UserId { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public bool? Status { get; set; }
    }
}
