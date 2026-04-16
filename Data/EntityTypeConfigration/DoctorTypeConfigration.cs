using Hospital_system.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;

namespace Hospital_system.Data.EntityTypeConfigration
{
    public class DoctorTypeConfigration : IEntityTypeConfiguration<Doctor>
    {
        public void Configure(EntityTypeBuilder<Doctor> builder)
        {
            builder.Property(e => e.Name).HasMaxLength(200);
            builder.Property(e => e.Specialization).HasMaxLength(200);

            builder.HasData(
                    new Doctor { Id = 1, Name = "Ahmed Hassan", Specialization = "Cardiology", Img = "doctor1.jpg" },
                    new Doctor { Id = 2, Name = "Mohamed Ali", Specialization = "Dermatology", Img = "doctor2.jpg" },
                    new Doctor { Id = 3, Name = "Sara Mostafa", Specialization = "Neurology", Img = "doctor3.jpg" },
                    new Doctor { Id = 4, Name = "Omar Khaled", Specialization = "Orthopedics", Img = "doctor4.jpg" },
                    new Doctor { Id = 5, Name = "Mariam Samy", Specialization = "Pediatrics", Img = "doctor5.jpg" },
                    new Doctor { Id = 6, Name = "Hossam Nabil", Specialization = "Ophthalmology", Img = "doctor6.jpg" }
                    );
        }
    }
}
