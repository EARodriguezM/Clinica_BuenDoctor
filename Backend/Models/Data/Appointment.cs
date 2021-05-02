using System;
using System.Collections.Generic;

#nullable disable

namespace BuenDoctorAPI.Models.Data
{
    public partial class Appointment
    {
        public string AppointmentId { get; set; }
        public string PatientId { get; set; }
        public string UserId { get; set; }
        public DateTime? Date { get; set; }
        public byte AppointmentTypeId { get; set; }

        public virtual AppointmentType AppointmentType { get; set; }
        public virtual Patient Patient { get; set; }
        public virtual User User { get; set; }
    }
}
