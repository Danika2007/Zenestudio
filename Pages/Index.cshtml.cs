
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Zenestudio.Data;
using Zenestudio.Models;

namespace Zenestudio.Pages
{
    public class IndexModel : PageModel
    {
        private readonly AppDbContext _context;

        public IndexModel(AppDbContext context)
        {
            _context = context;
        }

        public int EloadokSzama { get; set; }
        public int ProjektekSzama { get; set; }
        public int SavokSzama { get; set; }
        public int KeszProjektekSzama { get; set; }

        public IList<ZeneiProjekt> LegutobbiProjektek { get; set; }
            = new List<ZeneiProjekt>();

        public async Task OnGetAsync()
        {
            EloadokSzama = await _context.Eloadok.CountAsync();

            ProjektekSzama = await _context.ZeneiProjektek.CountAsync();

            SavokSzama = await _context.Savok.CountAsync();

            KeszProjektekSzama = await _context.ZeneiProjektek
                .CountAsync(p => p.Statusz == "Kész");

            LegutobbiProjektek = await _context.ZeneiProjektek
                .Include(p => p.Eloado)
                .OrderByDescending(p => p.LetrehozasDatum)
                .ThenByDescending(p => p.Id)
                .Take(5)
                .ToListAsync();
        }
    }
}
