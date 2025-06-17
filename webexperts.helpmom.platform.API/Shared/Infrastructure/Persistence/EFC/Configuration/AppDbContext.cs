using Microsoft.EntityFrameworkCore;
using EntityFrameworkCore.CreatedUpdatedDate.Extensions;
using webexperts.helpmom.platform.API.Domain.Model.Entities;
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
        
        //Medication entity configuration
        builder.Entity<Medication>(med =>
        {
            med.HasKey(m => m.Id);

            med.Property(m => m.Id)
                .IsRequired()
                .ValueGeneratedOnAdd();

            med.Property(m => m.Name).IsRequired().HasMaxLength(100);
            med.Property(m => m.Concentration).IsRequired().HasMaxLength(50);
            med.Property(m => m.Dose).IsRequired().HasMaxLength(50);
            med.Property(m => m.Via).IsRequired().HasMaxLength(50);
            med.Property(m => m.Presentation).IsRequired().HasMaxLength(50);
            med.Property(m => m.Manufacturer).IsRequired().HasMaxLength(100);
            med.Property(m => m.PrescriptionId).IsRequired();

            // Quantity
            med.OwnsOne(m => m.Quantity, q =>
            {
                q.WithOwner().HasForeignKey("Id");
                q.Property(x => x.Amount)
                    .HasColumnName("quantity_amount")
                    .IsRequired();
                q.Property(x => x.Unit)
                    .HasColumnName("quantity_unit")
                    .HasMaxLength(20)
                    .IsRequired();
            });

            // Frequency
            med.OwnsOne(m => m.Frequency, f =>
            {
                f.WithOwner().HasForeignKey("Id");
                f.Property(x => x.TimesPerDay)
                    .HasColumnName("frequency_times_per_day")
                    .IsRequired();
                f.Property(x => x.Schedule)
                    .HasColumnName("frequency_schedule")
                    .HasMaxLength(50)
                    .IsRequired();
            });

            // Duration
            med.OwnsOne(m => m.Duration, d =>
            {
                d.WithOwner().HasForeignKey("Id");
                d.Property(x => x.Value)
                    .HasColumnName("duration_value")
                    .IsRequired();
                d.Property(x => x.Unit)
                    .HasColumnName("duration_unit")
                    .HasMaxLength(20)
                    .IsRequired();
            });
        });


        
        
        
        builder.UseSnakeCaseNamingConvention();
    }
}