using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ManajemenRuangan.Api.Data;
using ManajemenRuangan.Api.Dtos;

namespace ManajemenRuangan.Api.Controllers;

[ApiController]
[Route("api/rooms")]
public class RoomsController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public RoomsController(ApplicationDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var rooms = await _context.Rooms
            .Select(r => new RoomResponseDto
            {
                Id = r.Id,
                Name = r.Name,
                Location = r.Location,
                Capacity = r.Capacity
            })
            .ToListAsync();

        return Ok(rooms);
    }
    

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var room = await _context.Rooms
            .Where(r => r.Id == id)
            .Select(r => new RoomResponseDto
            {
                Id = r.Id,
                Name = r.Name,
                Location = r.Location,
                Capacity = r.Capacity
            })
            .FirstOrDefaultAsync();

        if (room == null)
            return NotFound();

        return Ok(room);
    }
}
