using System;
using System.Collections.Generic;

#nullable disable

namespace BuenDoctorAPI.Models.Data
{
    public partial class UserType
    {
        public byte UserTypeId { get; set; }
        public string Description { get; set; }
        public bool? Status { get; set; }
    }
}
