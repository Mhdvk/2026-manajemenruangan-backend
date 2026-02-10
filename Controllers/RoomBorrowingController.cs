using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ManajemenRuangan.Api.Data;
using ManajemenRuangan.Api.Models;
using ManajemenRuangan.Api.Dtos;

namespace ManajemenRuangan.Api.Controllers;

[ApiController]
[Route("api/borrowings")]
public class RoomBorrowingController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public RoomBorrowingController(ApplicationDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var data = await _context.RoomBorrowings
            .Include(b => b.Room)
            .Select(b => new RoomBorrowingResponseDto
            {
                Id = b.Id,
                BorrowerName = b.BorrowerName,
                StartTime = b.StartTime,
                EndTime = b.EndTime,
                Status = b.Status,
                Room = new RoomSimpleDto
                {
                    Id = b.Room.Id,
                    Name = b.Room.Name,
                    Location = b.Room.Location
                }
            })
            .ToListAsync();

        return Ok(data);
    }

    [HttpGet("{id}")]
public async Task<IActionResult> GetById(int id)
{
    var borrowing = await _context.RoomBorrowings
        .Include(b => b.Room)
        .Where(b => b.Id == id)
        .Select(b => new RoomBorrowingResponseDto
        {
            Id = b.Id,
            BorrowerName = b.BorrowerName,
            StartTime = b.StartTime,
            EndTime = b.EndTime,
            Status = b.Status,
            Room = new RoomSimpleDto
            {
                Id = b.Room.Id,
                Name = b.Room.Name,
                Location = b.Room.Location
            }
        })
        .FirstOrDefaultAsync();

    if (borrowing == null)
        return NotFound("Borrowing not found");

    return Ok(borrowing);
}


    [HttpPost]
    public async Task<IActionResult> Create(CreateRoomBorrowingDto dto)
    {
        if (dto.EndTime <= dto.StartTime)
            return BadRequest("End time must be after start time");

        var conflict = await _context.RoomBorrowings.AnyAsync(b =>
            b.RoomId == dto.RoomId &&
            b.Status == "approved" &&
            dto.StartTime < b.EndTime &&
            dto.EndTime > b.StartTime
        );

        if (conflict)
            return BadRequest("Room already booked at that time");

        var borrowing = new RoomBorrowing
        {
            RoomId = dto.RoomId,
            BorrowerName = dto.BorrowerName,
            StartTime = dto.StartTime,
            EndTime = dto.EndTime,
            Status = "pending"
        };

        _context.RoomBorrowings.Add(borrowing);
        await _context.SaveChangesAsync();

        return Ok(borrowing.Id);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, UpdateRoomBorrowingDto dto)
    {
        if (dto.EndTime <= dto.StartTime)
            return BadRequest("End time must be after start time");

        var borrowing = await _context.RoomBorrowings.FindAsync(id);
        if (borrowing == null) return NotFound();

        var conflict = await _context.RoomBorrowings.AnyAsync(b =>
            b.Id != id &&
            b.RoomId == dto.RoomId &&
            b.Status == "approved" &&
            dto.StartTime < b.EndTime &&
            dto.EndTime > b.StartTime
        );

        if (conflict)
            return BadRequest("Room already booked at that time");

        borrowing.RoomId = dto.RoomId;
        borrowing.BorrowerName = dto.BorrowerName;
        borrowing.StartTime = dto.StartTime;
        borrowing.EndTime = dto.EndTime;

        await _context.SaveChangesAsync();
        return Ok();
    }


    [HttpPatch("{id}/approve")]
    public async Task<IActionResult> Approve(int id)
    {
        var borrowing = await _context.RoomBorrowings.FindAsync(id);
        if (borrowing == null) return NotFound();

        var conflict = await _context.RoomBorrowings.AnyAsync(b =>
            b.Id != id &&
            b.RoomId == borrowing.RoomId &&
            b.Status == "approved" &&
            borrowing.StartTime < b.EndTime &&
            borrowing.EndTime > b.StartTime
        );

        if (conflict)
            return BadRequest("Room already booked at that time");

        borrowing.Status = "approved";
        await _context.SaveChangesAsync();

        return Ok();
    }


    [HttpPatch("{id}/reject")]
    public async Task<IActionResult> Reject(int id)
    {
        var borrowing = await _context.RoomBorrowings.FindAsync(id);
        if (borrowing == null) return NotFound();

        borrowing.Status = "rejected";
        await _context.SaveChangesAsync();

        return Ok();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var borrowing = await _context.RoomBorrowings.FindAsync(id);
        if (borrowing == null) return NotFound();

        _context.RoomBorrowings.Remove(borrowing);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}
