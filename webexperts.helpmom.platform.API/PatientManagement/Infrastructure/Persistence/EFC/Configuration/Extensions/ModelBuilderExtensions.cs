using Microsoft.EntityFrameworkCore;
using webexperts.helpmom.platform.API.PatientManagement.Domain.Model.Aggregates;
using webexperts.helpmom.platform.API.PatientManagement.Domain.Model.Entities;

namespace webexperts.helpmom.platform.API.PatientManagement.Infrastructure.Persistence.EFC.Configuration.Extensions;

public static class ModelBuilderExtensions
{
    public static void ApplyPatientManagementConfiguration(this ModelBuilder builder)
    {
        // Patient Management Context
        builder.Entity<Doctor>().HasKey(d => d.Id);
        builder.Entity<Doctor>().Property(d => d.Id).IsRequired().ValueGeneratedOnAdd();
        
        builder.Entity<Patient>().HasKey(p => p.Id);
        builder.Entity<Patient>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Patient>().Property(p => p.Phone).HasMaxLength(15);
        builder.Entity<Patient>().Property(p => p.AssignedDoctorId);

        builder.Entity<Baby>().HasKey(b => b.Id);
        builder.Entity<Baby>().Property(b => b.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Baby>().Property(b => b.Name).HasMaxLength(50);
        builder.Entity<Baby>().Property(b => b.DateOfBirth);
        builder.Entity<Baby>().Property(b => b.Gender).HasMaxLength(10);
    }
}