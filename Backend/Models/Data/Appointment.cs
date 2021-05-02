using System;
using System.Collections.Generic;

#nullable disable

namespace BuenDoctorAPI.Models.Data
{
    public partial class Appointment
    {
        public string AppointmentId { get; set; }
        public string PatientId { get; set; }
        public string DataUserId { get; set; }
        public DateTime? Date { get; set; }
        public byte AppointmentTypeId { get; set; }

        public virtual AppointmentType AppointmentType { get; set; }
        public virtual DataUser DataUser { get; set; }
        public virtual Patient Patient { get; set; }
    }
}
