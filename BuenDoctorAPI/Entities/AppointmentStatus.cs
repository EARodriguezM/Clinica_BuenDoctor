using System;
using System.Collections.Generic;

#nullable disable

namespace BuenDoctorAPI.Entities
{
    public partial class AppointmentStatus
    {
        public AppointmentStatus()
        {
            Appointments = new HashSet<Appointment>();
        }

        public byte AppointmentStatusId { get; set; }
        public string Description { get; set; }
        public bool? Status { get; set; }

        public virtual ICollection<Appointment> Appointments { get; set; }
    }
}
