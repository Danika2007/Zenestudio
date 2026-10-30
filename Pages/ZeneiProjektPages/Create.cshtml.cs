
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Zenestudio.Data;
using Zenestudio.Models;

namespace Zenestudio.Pages.Projektek
{
    public class CreateModel : PageModel
    {
        private readonly AppDbContext _context;

        public CreateModel(AppDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public ZeneiProjekt ZeneiProjekt { get; set; } = new();

        public SelectList EloadokLista { get; set; } = null!;

        public async Task OnGetAsync()
        {
            await ListaBetoltese();
        }

        private async Task ListaBetoltese()
        {
            var eloadok = await _context.Eloadok
                .OrderBy(e => e.Nev)
                .ToListAsync();

            EloadokLista = new SelectList(
                eloadok, "Id", "Nev");
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                await ListaBetoltese();
                return Page();
            }

            bool letezik = await _context.Eloadok
                .AnyAsync(e => e.Id == ZeneiProjekt.EloadoId);

            if (!letezik)
            {
                ModelState.AddModelError(
                    "ZeneiProjekt.EloadoId",
                    "Válassz egy létező előadót!");

                await ListaBetoltese();
                return Page();
            }

            _context.ZeneiProjektek.Add(ZeneiProjekt);
            await _context.SaveChangesAsync();

            return RedirectToPage("Index");
        }
    }
}
