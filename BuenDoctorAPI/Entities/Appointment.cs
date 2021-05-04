using System;
using System.Collections.Generic;

#nullable disable

namespace BuenDoctorAPI.Entities
{
    public partial class Appointment
    {
        public string AppointmentId { get; set; }
        public string PatientId { get; set; }
        public string DataUserId { get; set; }
        public DateTime? Date { get; set; }
        public byte AppointmentStatusId { get; set; }

        public virtual AppointmentStatus AppointmentStatus { get; set; }
        public virtual DataUser DataUser { get; set; }
        public virtual Patient Patient { get; set; }
    }
}
