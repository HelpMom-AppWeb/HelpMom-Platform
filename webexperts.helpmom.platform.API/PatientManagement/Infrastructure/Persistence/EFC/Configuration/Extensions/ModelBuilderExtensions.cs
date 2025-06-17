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
        builder.Entity<Doctor>().Property(d => d.ProfileId).IsRequired();
        builder.Entity<Doctor>()
            .HasMany(d => d.Patients)
            .WithOne(p => p.AssignedDoctor)
            .HasForeignKey(p => p.AssignedDoctorId)
            .IsRequired();
        
        builder.Entity<Patient>().HasKey(p => p.Id);
        builder.Entity<Patient>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Patient>().Property(p => p.ProfileId).IsRequired();
        builder.Entity<Patient>().Property(p => p.Phone).HasMaxLength(15);
        builder.Entity<Patient>().OwnsOne(p => p.Baby, b =>
        {
            b.WithOwner().HasForeignKey("MotherId");
            b.Property(p => p.Id).HasColumnName("BabyId");
        });
        builder.Entity<Patient>().Property(p => p.AssignedDoctorId).IsRequired();

        builder.Entity<Baby>().HasKey(p => p.Id);
        builder.Entity<Baby>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Baby>().Property(p => p.Name).IsRequired().HasMaxLength(50);
        builder.Entity<Baby>().Property(p => p.DateOfBirth).IsRequired();
        builder.Entity<Baby>().Property(p => p.Gender).IsRequired().HasMaxLength(10);
        builder.Entity<Baby>().Property(p => p.MotherId).IsRequired();

    }
}