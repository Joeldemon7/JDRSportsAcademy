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
    public class DetailsModel : PageModel
    {
        private readonly JDRSportsAcademy.Data.SportContext _context;

        public DetailsModel(JDRSportsAcademy.Data.SportContext context)
        {
            _context = context;
        }

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
    }
}

