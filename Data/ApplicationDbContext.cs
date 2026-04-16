using Hospital_system.Data.EntityTypeConfigration;
using Hospital_system.Models;
using Microsoft.EntityFrameworkCore;

namespace Hospital_system.Data
{
    public class ApplicationDbContext :DbContext
    {
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Appointment> Appointments { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder.UseSqlServer("Data Source=.\\SQLEXPRESS04;Integrated Security=True;Initial Catalog =hospital_System" +
                ";Persist Security Info=False;Pooling=False;Encrypt=True;TrustServerCertificate=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(DoctorTypeConfigration).Assembly);

        }
    }
}
