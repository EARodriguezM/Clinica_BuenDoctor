using System;
using System.Collections.Generic;

#nullable disable

namespace BuenDoctorAPI.Models.Data
{
    public partial class AppointmentType
    {
        public AppointmentType()
        {
            Appointments = new HashSet<Appointment>();
        }

        public byte AppointmentTypeId { get; set; }
        public string Description { get; set; }
        public bool? Status { get; set; }

        public virtual ICollection<Appointment> Appointments { get; set; }
    }
}
