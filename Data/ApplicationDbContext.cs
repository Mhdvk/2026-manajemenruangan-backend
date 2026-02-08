using ManajemenRuangan.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace ManajemenRuangan.Api.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<Room> Rooms => Set<Room>();
    public DbSet<RoomBorrowing> RoomBorrowings => Set<RoomBorrowing>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Room>()
            .HasMany(r => r.RoomBorrowings)
            .WithOne(rb => rb.Room)
            .HasForeignKey(rb => rb.RoomId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
