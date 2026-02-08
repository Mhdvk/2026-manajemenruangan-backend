using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ManajemenRuangan.Api.Data;
using ManajemenRuangan.Api.Models;

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
        return Ok(await _context.RoomBorrowings
            .Include(b => b.Room)
            .ToListAsync());
    }

    [HttpPost]
    public async Task<IActionResult> Create(RoomBorrowing borrowing)
    {
        _context.RoomBorrowings.Add(borrowing);
        await _context.SaveChangesAsync();
        return Ok(borrowing);
    }
}
