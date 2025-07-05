using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using webexperts.helpmom.platform.API.Chat.Domain.Model.Aggregates;
using webexperts.helpmom.platform.API.Chat.Domain.Model.ValueObjects;

namespace webexperts.helpmom.platform.API.Chat.Infrastructure.Persistence.Configurations
{
    public class MessageConfiguration : IEntityTypeConfiguration<Message>
    {
        public void Configure(EntityTypeBuilder<Message> builder)
        {
            builder.ToTable("Messages");

            builder.HasKey(m => m.Id);

            builder.OwnsOne(m => m.From, from =>
            {
                from.Property(f => f.UserId).HasColumnName("FromUserId");
                from.Property(f => f.Role).HasColumnName("FromRole");
            });

            builder.Property(m => m.Text).IsRequired();
            builder.Property(m => m.Timestramp);
            builder.Property(m => m.patientId);
        }
    }
}

