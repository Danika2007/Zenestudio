
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Zenestudio.Data;
using Zenestudio.Models;

namespace Zenestudio.Pages.Savok
{
    public class CreateModel : PageModel
    {
        private readonly AppDbContext _context;

        public CreateModel(AppDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Sav Sav { get; set; } = new();

        public SelectList ProjektekLista { get; set; } = null!;

        public async Task OnGetAsync()
        {
            await ListaBetoltese();
        }

        private async Task ListaBetoltese()
        {
            var projektek = await _context.ZeneiProjektek
                .OrderBy(p => p.Cim)
                .ToListAsync();

            ProjektekLista = new SelectList(
                projektek, "Id", "Cim");
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                await ListaBetoltese();
                return Page();
            }

            bool letezik = await _context.ZeneiProjektek
                .AnyAsync(p => p.Id == Sav.ProjektId);

            if (!letezik)
            {
                ModelState.AddModelError(
                    "Sav.ProjektId",
                    "Válassz egy létező projektet!");

                await ListaBetoltese();
                return Page();
            }

            _context.Savok.Add(Sav);
            await _context.SaveChangesAsync();

            return RedirectToPage("Index");
        }
    }
}
