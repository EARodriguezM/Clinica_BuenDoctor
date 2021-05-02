using System;
using System.Collections.Generic;

#nullable disable

namespace BuenDoctorAPI.Models.Data
{
    public partial class RUserUserType
    {
        public string UserId { get; set; }
        public byte UserTypeId { get; set; }
        public bool? Status { get; set; }

        public virtual User User { get; set; }
        public virtual UserType UserType { get; set; }
    }
}
