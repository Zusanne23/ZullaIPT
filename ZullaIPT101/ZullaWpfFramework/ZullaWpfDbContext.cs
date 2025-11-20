using Microsoft.EntityFrameworkCore;
using ZullaWpfFramework.DTOs;

namespace ZullaWpfFramework;

public class ZullaWpfDbContext : DbContext
{
    public ZullaWpfDbContext(DbContextOptions<ZullaWpfDbContext> options) : base(options)
    {
    }

    public DbSet<DanceClassDto> DanceClasses { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<DanceClassDto>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Title).IsRequired().HasMaxLength(200);
            entity.Property(e => e.DanceStyle).IsRequired().HasMaxLength(100);
            entity.Property(e => e.Instructor).IsRequired().HasMaxLength(200);
            entity.Property(e => e.Schedule).IsRequired().HasMaxLength(200);
        });

        base.OnModelCreating(modelBuilder);
    }
}
