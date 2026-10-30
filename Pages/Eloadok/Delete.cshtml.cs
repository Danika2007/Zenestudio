using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Zenestudio.Models;
using Zenestudio.Data;

namespace Zenestudio.Pages.Eloadok;

public class DeleteModel : PageModel
{
    private readonly AppDbContext _context;

    public DeleteModel(AppDbContext context)
    {
        _context = context;
    }

    [BindProperty]
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

    public async Task<IActionResult> OnPostAsync(int? id)
    {
        if (id is null)
        {
            return NotFound();
        }

        var eloado = await _context.Eloadok.FindAsync(id);
        if (eloado != null)
        {
            Eloado = eloado;
            _context.Eloadok.Remove(Eloado);
            await _context.SaveChangesAsync();
        }

        return RedirectToPage("./Index");
    }
}
