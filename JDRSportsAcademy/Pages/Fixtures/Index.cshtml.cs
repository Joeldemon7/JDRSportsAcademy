using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using JDRSportsAcademy.Data;
using JDRSportsAcademy.Models;

namespace JDRSportsAcademy.Pages.Fixtures
{
    public class IndexModel : PageModel
    {
        private readonly SportContext _context;

        public IndexModel(SportContext context)
        {
            _context = context;
        }

        public IList<Fixture> Fixture { get; private set; } = default!;

        public async Task OnGetAsync()
        {
            // Fetch the list of fixtures, including related sports and students.
            if (_context.Fixtures != null)
            {
                Fixture = await _context.Fixtures
                                        .Include(f => f.Sport)
                                        .Include(f => f.Student)
                                        .ToListAsync();
            }
        }
    }
}

