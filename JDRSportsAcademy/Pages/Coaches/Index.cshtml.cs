using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using JDRSportsAcademy.Data;
using JDRSportsAcademy.Models;

namespace JDRSportsAcademy.Pages.Coaches
{
    public class IndexModel : PageModel
    {
        private readonly SportContext _context;

        public IndexModel(SportContext context)
        {
            _context = context;
        }

        public IList<Coach> Coach { get; private set; } = default!;

        public async Task OnGetAsync()
        {
            // Fetch the list of coaches along with their associated sport details.
            if (_context.Coaches != null)
            {
                Coach = await _context.Coaches
                                      .Include(c => c.Sport)
                                      .ToListAsync();
            }
        }
    }
}

