using Hospital_system.Models;

namespace Hospital_system.ViewModel
{
    public class DoctorVM
    {
        public List<Doctor> Doctors { get; set; } = [];
        public string? Name { get; set; }
    }
}
