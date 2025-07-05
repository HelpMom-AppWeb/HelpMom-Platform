using Microsoft.EntityFrameworkCore;
using webexperts.helpmom.platform.API.PatientManagement.Domain.Model.Aggregates;

namespace webexperts.helpmom.platform.API.PatientManagement.Infrastructure.Persistence.EFC.Configuration.Extensions;

public static class ModelBuilderExtensions
{
    public static void ApplyPatientManagementConfiguration(this ModelBuilder builder)
    {
        // Patient Management Context
        builder.Entity<Doctor>().HasKey(d => d.Id);
        builder.Entity<Doctor>().Property(d => d.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Doctor>().Property(d => d.Name).IsRequired();
        
        builder.Entity<Patient>().HasKey(p => p.Id);
        builder.Entity<Patient>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd().HasColumnName("patient_id");
        builder.Entity<Patient>().Property(p => p.Name).IsRequired().HasMaxLength(40);
        builder.Entity<Patient>().Property(p => p.Email).IsRequired().HasMaxLength(40);
        builder.Entity<Patient>().Property(p => p.Phone).HasMaxLength(9).IsRequired();
        builder.Entity<Patient>().Property(p => p.AssignedDoctorId).IsRequired();
        builder.Entity<Patient>().OwnsOne(p => p.Baby, baby =>
        {
            baby.Property(b => b.Name).IsRequired().HasMaxLength(40).HasColumnName("baby_name");
            baby.Property(b => b.DateOfBirth).IsRequired();
            baby.Property(b => b.Gender).IsRequired();
        });
        
    }
}