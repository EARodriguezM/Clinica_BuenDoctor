using System;
using System.Collections.Generic;

#nullable disable

namespace BuenDoctorAPI.Models.Data
{
    public partial class UserType
    {
        public UserType()
        {
            RDataUserUserTypes = new HashSet<RDataUserUserType>();
        }

        public byte UserTypeId { get; set; }
        public string Description { get; set; }
        public bool? Status { get; set; }

        public virtual ICollection<RDataUserUserType> RDataUserUserTypes { get; set; }
    }
}
