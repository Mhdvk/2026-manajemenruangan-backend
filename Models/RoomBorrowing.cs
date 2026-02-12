using ManajemenRuangan.Api.Models.Enums;
namespace ManajemenRuangan.Api.Models;

public class RoomBorrowing
{
    public int Id { get; set; }

    public int RoomId { get; set; }
    public Room Room { get; set; } = null!;

    public string BorrowerName { get; set; } = null!;
    public DateTime StartTime { get; set; }
    public BorrowingStatus Status { get; set; }
    public DateTime EndTime { get; set; }
    public string? Tujuan { get; set; }
}
