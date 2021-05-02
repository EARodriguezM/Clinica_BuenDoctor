using System;
using System.Collections.Generic;

#nullable disable

namespace BuenDoctorAPI.Models.Data
{
    public partial class RDataUserUserType
    {
        public string RDataUserUserTypeId { get; set; }
        public string DataUserId { get; set; }
        public byte UserTypeId { get; set; }
        public bool? Status { get; set; }

        public virtual DataUser DataUser { get; set; }
        public virtual UserType UserType { get; set; }
    }
}
