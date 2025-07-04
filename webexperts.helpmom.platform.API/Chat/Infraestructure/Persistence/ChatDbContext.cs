using Microsoft.EntityFrameworkCore;
using webexperts.helpmom.platform.API.Chat.Domain.Model.Aggregates;

namespace webexperts.helpmom.platform.API.Chat.Infraestructure.Persistence;

public class ChatDbContext : DbContext
{
    public ChatDbContext(DbContextOptions<ChatDbContext> options) : base(options) { }

    public DbSet<Message> Messages { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ChatDbContext).Assembly);
        base.OnModelCreating(modelBuilder);
    }
}