using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using JDRSportsAcademy.Data;
using JDRSportsAcademy.Models;

namespace JDRSportsAcademy.Pages.Sports
{
    public class DeleteModel : PageModel
    {
        private readonly JDRSportsAcademy.Data.SportContext _context;

        public DeleteModel(JDRSportsAcademy.Data.SportContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Sport Sport { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Sports == null)
            {
                return NotFound();
            }

            Sport = await _context.Sports.FirstOrDefaultAsync(m => m.SportID == id);

            if (Sport == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Sports == null)
            {
                return NotFound();
            }

            var sport = await _context.Sports.FindAsync(id);

            if (sport != null)
            {
                try
                {
                    Sport = sport;
                    _context.Sports.Remove(Sport);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateException)
                {
                    // Log the exception and return an error view or message
                    return RedirectToPage("./Error");
                }
            }

            return RedirectToPage("./Index");
        }
    }
}

