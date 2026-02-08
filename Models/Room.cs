namespace ManajemenRuangan.Api.Models;

public class Room
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string Location { get; set; } = null!;
    public int Capacity { get; set; }

    public ICollection<RoomBorrowing> RoomBorrowings { get; set; }
        = new List<RoomBorrowing>();
}
