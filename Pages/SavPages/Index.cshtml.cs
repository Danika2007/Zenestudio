
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Zenestudio.Data;
using Zenestudio.Models;

namespace Zenestudio.Pages.Savok
{
    public class IndexModel : PageModel
    {
        private readonly AppDbContext _context;

        public IndexModel(AppDbContext context)
        {
            _context = context;
        }

        public IList<Sav> Sav { get; set; } = new List<Sav>();

        public async Task OnGetAsync()
        {
            Sav = await _context.Savok
                .Include(s => s.Projekt)
                .OrderBy(s => s.SavNev)
                .ToListAsync();
        }
    }
}
