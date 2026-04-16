namespace Hospital_system.Models
{
    public class Patient
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();

    }
}
