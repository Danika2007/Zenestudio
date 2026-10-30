
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Zenestudio.Data;
using Zenestudio.Models;

namespace Zenestudio.Pages.Eloadok
{
    public class CreateModel : PageModel
    {
        private readonly AppDbContext _context;

        public CreateModel(AppDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Eloado Eloado { get; set; } = new();

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
                return Page();

            _context.Eloadok.Add(Eloado);
            await _context.SaveChangesAsync();

            return RedirectToPage("Index");
        }
    }
}
