using System.Diagnostics;
using Hospital_system.Data;
using Hospital_system.Models;
using Hospital_system.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace Hospital_system.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context =new();


        public IActionResult Index()
        {
            return View();
        }

        
        public IActionResult BookAppointment(string? name = null)
        {
            var doctors = _context.Doctors.AsQueryable();
            if (!string.IsNullOrEmpty(name))
            {
                doctors = doctors.Where(e => e.Name.Contains(name));
            }
            return View(new DoctorVM ()
            {
                Doctors=doctors.ToList(),
                Name=name
            });

        }

        [HttpGet]
        public IActionResult CompleteAppointment(int id)
        {
            var doctor = _context.Doctors.FirstOrDefault(d => d.Id == id);
            if (doctor == null) return NotFound();
            var bookedTimes = _context.Appointments
                .Where(a => a.DoctorId == id)
                .Select(a => a.AppointmentTime.ToString(@"hh\:mm"))
                .ToList();//ÈÊÌíÈáí ÇáÈíÇäÇÊ ãä ÇáÏÇÊÇ ÈíÒ    

            ViewBag.BookedTimes = bookedTimes;

            return View(doctor);
        }

        [HttpPost]
        public IActionResult CompleteAppointment(AppointmentVM appointmentVM)
        {
            var doctor=_context.Doctors.FirstOrDefault(e=>e.Id==appointmentVM.DoctorId);
            if(doctor ==null) return NotFound();

            var day = appointmentVM.AppointmentDate.DayOfWeek;

            if(day==DayOfWeek.Friday||day==DayOfWeek.Saturday)
            {               
                return View(doctor);
            }

            if(appointmentVM.AppointmentTime<new TimeOnly(8,0)||
                appointmentVM.AppointmentTime>new TimeOnly(17,0))
            {               
                return View(doctor);
            }

            var exist = _context.Appointments.Any(e =>
            e.DoctorId == appointmentVM.DoctorId &&
            e.AppointmentDate == appointmentVM.AppointmentDate &&
            e.AppointmentTime==appointmentVM.AppointmentTime
            );

            if (exist)
            {
                return View(doctor);
            }

                var patient = _context.Patients.FirstOrDefault(e => e.Name == appointmentVM.PatientName);
            if (patient == null)
            {
                patient = new Patient
                {
                    Name = appointmentVM.PatientName,
                };
                _context.Patients.Add(patient);  
                _context.SaveChanges();
                
            }
            Appointment appointment = new Appointment
            {
                DoctorId = appointmentVM.DoctorId,
                PatientId = patient.Id,
                AppointmentDate = appointmentVM.AppointmentDate,
                AppointmentTime = appointmentVM.AppointmentTime,
            };
            _context.Appointments.Add(appointment);
            _context.SaveChanges();

            
            return RedirectToAction(nameof(BookAppointment));
        }
         
        public IActionResult ReservationsManagement()
        {
            var appointments = _context.Appointments.Include(e => e.patient)
                .Include(e=>e.doctor).AsQueryable();
            return View(appointments.AsEnumerable());
        }













            [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
