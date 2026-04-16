using Hospital_system.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hospital_system.Data.EntityTypeConfigration
{
    public class PatientEntityTypeConfigration : IEntityTypeConfiguration<Patient>
    {
        public void Configure(EntityTypeBuilder<Patient> builder)
        {
            builder.Property(e => e.Name).HasMaxLength(256);
        }
    }
}
