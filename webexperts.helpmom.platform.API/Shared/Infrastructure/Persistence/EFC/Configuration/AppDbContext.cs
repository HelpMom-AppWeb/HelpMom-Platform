using EntityFrameworkCore.CreatedUpdatedDate.Extensions;
using Microsoft.EntityFrameworkCore;
using webexperts.helpmom.platform.API.Appointments.Domain.Model.Aggregates;
using webexperts.helpmom.platform.API.HealthMonitoring.Domain.Model.Aggregates;
using webexperts.helpmom.platform.API.Shared.Infrastructure.Persistence.EFC.Configuration.Extensions;

namespace webexperts.helpmom.platform.API.Shared.Infrastructure.Persistence.EFC.Configuration;

public class AppDbContext(DbContextOptions options) : DbContext(options)
{
    protected override void OnConfiguring(DbContextOptionsBuilder builder)
    {
        // Add the created and updated interceptor
        builder.AddCreatedUpdatedInterceptor();
        base.OnConfiguring(builder);
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        
        builder.Entity<HealthData>().HasKey(f => f.Id);
        builder.Entity<HealthData>().Property(f => f.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<HealthData>().Property(f => f.HeartRate).IsRequired();
        builder.Entity<HealthData>().Property(f => f.Temperature).IsRequired();
        builder.Entity<HealthData>().Property(f => f.Weight).IsRequired();
        builder.Entity<HealthData>().Property(f => f.OxygenSaturation).IsRequired();
        builder.Entity<HealthData>().Property(f => f.PatientId).IsRequired();
        
        builder.UseSnakeCaseNamingConvention();
        
        builder.Entity<Appointment>(entity =>
        {
            entity.HasKey(e => e.Id);

            entity.Property(e => e.Id)
                .HasColumnName("id")
                .ValueGeneratedOnAdd(); 
        });
    }
    public DbSet<Appointment> Appointments { get; set; }
}