using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Zenestudio.Models;
using Zenestudio.Data;

namespace Zenestudio.Pages.SavPages;

public class DeleteModel : PageModel
{
    private readonly AppDbContext _context;

    public DeleteModel(AppDbContext context)
    {
        _context = context;
    }

    [BindProperty]
    public Sav Sav { get; set; } = default!;

    public async Task<IActionResult> OnGetAsync(int? id)
    {
        if (id is null)
        {
            return NotFound();
        }

        var sav = await _context.Savok.FirstOrDefaultAsync(m => m.Id == id);
        if (sav is null)
        {
            return NotFound();
        }
        else
        {
            Sav = sav;
        }

        return Page();
    }

    public async Task<IActionResult> OnPostAsync(int? id)
    {
        if (id is null)
        {
            return NotFound();
        }

        var sav = await _context.Savok.FindAsync(id);
        if (sav != null)
        {
            Sav = sav;
            _context.Savok.Remove(Sav);
            await _context.SaveChangesAsync();
        }

        return RedirectToPage("./Index");
    }
}
