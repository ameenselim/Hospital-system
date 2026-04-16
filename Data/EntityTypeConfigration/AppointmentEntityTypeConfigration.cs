using Hospital_system.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hospital_system.Data.EntityTypeConfigration
{
    public class AppointmentEntityTypeConfigration : IEntityTypeConfiguration<Appointment>
    {
        public void Configure(EntityTypeBuilder<Appointment> builder)
        {

            builder.HasKey(db => db.Id);

            builder.HasOne(db => db.doctor)
                .WithMany(d => d.Appointments)
                .HasForeignKey(db => db.DoctorId);

            builder.HasOne(db => db.patient)
                .WithMany(p => p.Appointments)
                .HasForeignKey(db => db.PatientId);
                
        }
    }
}
