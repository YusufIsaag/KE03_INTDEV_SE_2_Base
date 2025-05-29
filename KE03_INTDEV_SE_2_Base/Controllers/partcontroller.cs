using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DataAccessLayer.Models;
using DataAccessLayer;

public class PartsController : Controller
{
    private readonly MatrixIncDbContext _context;

    public PartsController(MatrixIncDbContext context)
    {
        _context = context;
    }

    public async Task<IActionResult> Index()
    {
        var parts = await _context.Parts.Include(p => p.Products).ToListAsync();
        return View(parts);
    }

    public async Task<IActionResult> Details(int id)
    {
        var parts = await _context.Parts
            .Include(p => p.Products)
            .FirstOrDefaultAsync(m => m.Id == id);

        if (parts == null)
            return NotFound();

        return View(parts);
    }

    
}

