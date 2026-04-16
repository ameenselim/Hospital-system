namespace Hospital_system.ViewModel
{
    public class AppointmentVM
    {
        public int DoctorId { get; set; }
        public string PatientName { get; set; } = null!;
        public DateOnly AppointmentDate { get; set; }
        public TimeOnly AppointmentTime { get; set; }
    }
}
