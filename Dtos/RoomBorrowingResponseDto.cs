namespace ManajemenRuangan.Api.Dtos;
using ManajemenRuangan.Api.Models.Enums;
public class RoomBorrowingResponseDto
{
    public int Id { get; set; }
    public string BorrowerName { get; set; } = string.Empty;
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }
    public BorrowingStatus Status { get; set; }
    public string? Tujuan { get; set; }
    public RoomSimpleDto Room { get; set; } = null!;
}
