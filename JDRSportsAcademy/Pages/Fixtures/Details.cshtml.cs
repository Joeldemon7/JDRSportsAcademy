using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using JDRSportsAcademy.Data;
using JDRSportsAcademy.Models;

namespace JDRSportsAcademy.Pages.Fixtures
{
    public class DetailsModel : PageModel
    {
        private readonly JDRSportsAcademy.Data.SportContext _context;

        public DetailsModel(JDRSportsAcademy.Data.SportContext context)
        {
            _context = context;
        }

        public Fixture Fixture { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Fixtures == null)
            {
                return NotFound();
            }

            // Include related entities
            var fixture = await _context.Fixtures
                .Include(f => f.Sport)
                .Include(f => f.Student)
                .FirstOrDefaultAsync(m => m.FixtureID == id);

            if (fixture == null)
            {
                return NotFound();
            }
            else
            {
                Fixture = fixture;
            }
            return Page();
        }
    }
}

