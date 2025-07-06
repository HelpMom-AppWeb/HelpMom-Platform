using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using webexperts.helpmom.platform.API.Chat.Domain.Model.Aggregates;
using webexperts.helpmom.platform.API.Chat.Domain.Model.ValueObjects;

namespace webexperts.helpmom.platform.API.Chat.Infraestructure.Persistence.Configurations
{
    public static class ModelBuilderExtensions
    {
        public static void ApplyChatConfiguration(this ModelBuilder builder)
        {
            builder.Entity<Message>().HasKey(m => m.Id);
            builder.Entity<Message>().Property(m => m.Id).HasColumnName("message_id").ValueGeneratedOnAdd();
            builder.Entity<Message>().OwnsOne(m => m.From, from =>
            {
                from.Property(f => f.UserId).HasColumnName("from_user_id");
                from.Property(f => f.Role).HasColumnName("from_role");
            });

            builder.Entity<Message>().Property(m => m.Text).IsRequired();
            builder.Entity<Message>().Property(m => m.Timestramp);
            builder.Entity<Message>().Property(m => m.PatientId).HasColumnName("patient_id");
        }
    }
}

