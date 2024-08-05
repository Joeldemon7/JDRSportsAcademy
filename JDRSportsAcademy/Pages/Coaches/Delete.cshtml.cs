using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using JDRSportsAcademy.Data;
using JDRSportsAcademy.Models;

namespace JDRSportsAcademy.Pages.Coaches
{
    public class DeleteModel : PageModel
    {
        private readonly JDRSportsAcademy.Data.SportContext _context;

        public DeleteModel(JDRSportsAcademy.Data.SportContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Coach Coach { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Coaches == null)
            {
                return NotFound();
            }

            Coach = await _context.Coaches
                                  .Include(c => c.Sport)
                                  .FirstOrDefaultAsync(m => m.CoachID == id);

            if (Coach == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Coaches == null)
            {
                return NotFound();
            }

            Coach = await _context.Coaches.FindAsync(id);

            if (Coach != null)
            {
                _context.Coaches.Remove(Coach);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}

