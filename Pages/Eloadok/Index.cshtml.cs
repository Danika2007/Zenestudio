
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Zenestudio.Data;
using Zenestudio.Models;

namespace Zenestudio.Pages.Eloadok
{
    public class IndexModel : PageModel
    {
        private readonly AppDbContext _context;

        public IndexModel(AppDbContext context)
        {
            _context = context;
        }

        public List<Eloado> Eloadok { get; set; } = new();

        public async Task OnGetAsync()
        {
            Eloadok = await _context.Eloadok
                .OrderBy(e => e.Nev)
                .ToListAsync();
        }
    }
}
