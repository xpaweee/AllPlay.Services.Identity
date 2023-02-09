using Messier.Postgres.OutboxPattern.Base;
using Microsoft.EntityFrameworkCore;

namespace AllPlay.Services.Identity.Infrastructure.DAL;

public class IdentityDbContext : DbContext
{
    public DbSet<OutboxMessage> Outbox { get; set; } = null!;

    public IdentityDbContext(DbContextOptions<IdentityDbContext> options) : base(options)
    {
        
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
    }
}