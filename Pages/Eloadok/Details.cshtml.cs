using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Zenestudio.Models;
using Zenestudio.Data;

namespace Zenestudio.Pages.Eloadok;

public class DetailsModel : PageModel
{
    private readonly AppDbContext _context;
    public DetailsModel(AppDbContext context)
    {
        _context = context;
    }

    public Eloado Eloado { get; set; } = default!;

    public async Task<IActionResult> OnGetAsync(int? id)
    {
        if (id is null)
        {
            return NotFound();
        }

        var eloado = await _context.Eloadok.FirstOrDefaultAsync(m => m.Id == id);
        if (eloado is null)
        {
            return NotFound();
        }
        else
        {
            Eloado = eloado;
        }

        return Page();
    }
}
