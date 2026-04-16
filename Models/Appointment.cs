namespace Hospital_system.Models
{
    public class Appointment
    {
        public int Id { get; set; }
        public int DoctorId { get; set; }
        public Doctor doctor { get; set; } = null!;
        public int PatientId { get; set; }
        public Patient patient { get; set; } = null!;
        public DateOnly AppointmentDate { get; set; }
        public TimeOnly AppointmentTime { get; set; }

    }
}
