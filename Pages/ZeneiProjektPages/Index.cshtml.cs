
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Zenestudio.Data;
using Zenestudio.Models;

namespace Zenestudio.Pages.Projektek
{
    public class IndexModel : PageModel
    {
        private readonly AppDbContext _context;

        public IndexModel(AppDbContext context)
        {
            _context = context;
        }

        public IList<ZeneiProjekt> ZeneiProjekt { get; set; }
            = new List<ZeneiProjekt>();

        public string Kereses { get; set; } = "";
        public string Statusz { get; set; } = "";

        public async Task OnGetAsync(
            string? kereses,
            string? statusz)
        {
            Kereses = kereses ?? "";
            Statusz = statusz ?? "";

            var query = _context.ZeneiProjektek
                .Include(p => p.Eloado)
                .AsQueryable();

            if (!string.IsNullOrWhiteSpace(Kereses))
            {
                query = query.Where(p =>
                    p.Cim.Contains(Kereses));
            }

            if (!string.IsNullOrWhiteSpace(Statusz))
            {
                query = query.Where(p =>
                    p.Statusz == Statusz);
            }

            ZeneiProjekt = await query
                .OrderByDescending(p => p.Id)
                .ToListAsync();
        }
    }
}
