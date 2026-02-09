using System.ComponentModel.DataAnnotations;

namespace ManajemenRuangan.Api.Dtos;

public class CreateRoomDto
{
    [Required]
    public string Name { get; set; } = string.Empty;

    [Required]
    public string Location { get; set; } = string.Empty;

    [Required]
    public int Capacity { get; set; }
}
