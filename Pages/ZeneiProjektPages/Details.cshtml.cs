using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Zenestudio.Models;
using Zenestudio.Data;

namespace Zenestudio.Pages.ZeneiProjektPages;

public class DetailsModel : PageModel
{
    private readonly AppDbContext _context;
    public DetailsModel(AppDbContext context)
    {
        _context = context;
    }

    public ZeneiProjekt ZeneiProjekt { get; set; } = default!;

    public async Task<IActionResult> OnGetAsync(int? id)
    {
        if (id is null)
        {
            return NotFound();
        }

        var zeneiprojekt = await _context.ZeneiProjektek.FirstOrDefaultAsync(m => m.Id == id);
        if (zeneiprojekt is null)
        {
            return NotFound();
        }
        else
        {
            ZeneiProjekt = zeneiprojekt;
        }

        return Page();
    }
}
