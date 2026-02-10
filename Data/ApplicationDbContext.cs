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
    base.OnModelCreating(modelBuilder);

    modelBuilder.Entity<Room>()
        .HasMany(r => r.RoomBorrowings)
        .WithOne(rb => rb.Room)
        .HasForeignKey(rb => rb.RoomId)
        .OnDelete(DeleteBehavior.Cascade);

    modelBuilder.Entity<Room>().HasData(
        new Room
        {
            Id = 1,
            Name = "Lab Jaringan Komputer",
            Location = "C305",
            Capacity = 30
        },
        new Room
        {
            Id = 2,
            Name = "Lab Database",
            Location = "C105",
            Capacity = 25
        },
        new Room
        {
            Id = 3,
            Name = "Lab Agile",
            Location = "C206",
            Capacity = 15
        },
        new Room
        {
            Id = 4,
            Name = "Ruangan Kelas",
            Location = "A201",
            Capacity = 15
        },
        new Room
        {
            Id = 5,
            Name = "Ruangan Kelas",
            Location = "A202",
            Capacity = 15
        },
        new Room
        {
            Id = 6,
            Name = "Ruangan Kelas",
            Location = "A203",
            Capacity = 15
        },
        new Room
        {
            Id = 7,
            Name = "Ruangan Kelas",
            Location = "A204",
            Capacity = 15
        },
        new Room
        {
            Id = 8,
            Name = "Ruangan Kelas",
            Location = "A205",
            Capacity = 15
        },
        new Room
        {
            Id = 9,
            Name = "Ruangan Kelas",
            Location = "A301",
            Capacity = 15
        },
        new Room
        {
            Id = 10,
            Name = "Ruangan Kelas",
            Location = "A302",
            Capacity = 15
        },
        new Room
        {
            Id = 11,
            Name = "Ruangan Kelas",
            Location = "A303",
            Capacity = 15
        },
        new Room
        {
            Id = 12,
            Name = "Ruangan Kelas",
            Location = "A304",
            Capacity = 15
        },
        new Room
        {
            Id = 13,
            Name = "Ruangan Kelas",
            Location = "A305",
            Capacity = 15
        },
        new Room
        {
            Id = 14,
            Name = "Student Center",
            Location = "Gedung Student Center",
            Capacity = 15
        },
        new Room
        {
            Id = 15,
            Name = "Masjid An-Nahl",
            Location = "Masjid An Nahl",
            Capacity = 15
        }
    );
}

}
