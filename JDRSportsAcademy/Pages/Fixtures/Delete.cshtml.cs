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
    public class DeleteModel : PageModel
    {
        private readonly JDRSportsAcademy.Data.SportContext _context;

        public DeleteModel(JDRSportsAcademy.Data.SportContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Fixture Fixture { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Fixtures == null)
            {
                return NotFound();
            }

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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Fixtures == null)
            {
                return NotFound();
            }
            var fixture = await _context.Fixtures.FindAsync(id);

            if (fixture != null)
            {
                Fixture = fixture;
                _context.Fixtures.Remove(Fixture);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
