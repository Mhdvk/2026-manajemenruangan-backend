using System.ComponentModel.DataAnnotations;

namespace ManajemenRuangan.Api.Dtos;

public class CreateRoomBorrowingDto
{
    [Required]
    public int RoomId { get; set; }

    [Required]
    public string BorrowerName { get; set; } = string.Empty;

    [Required]
    public DateTime StartTime { get; set; }

    [Required]
    public DateTime EndTime { get; set; }
}
