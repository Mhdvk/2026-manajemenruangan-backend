namespace ManajemenRuangan.Api.Dtos;

public class RoomBorrowingResponseDto
{
    public int Id { get; set; }
    public string BorrowerName { get; set; } = string.Empty;
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }
    public string Status { get; set; } = string.Empty;
    public string? Tujuan { get; set; }
    public RoomSimpleDto Room { get; set; } = null!;
}
