using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using JDRSportsAcademy.Data;
using JDRSportsAcademy.Models;
using System.Threading.Tasks;

namespace JDRSportsAcademy.Pages.Students
{
    public class DetailsModel : PageModel
    {
        private readonly SportContext _context;

        public DetailsModel(SportContext context)
        {
            _context = context;
        }

        public Student Student { get; private set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (!id.HasValue)
            {
                return NotFound();
            }

            Student = await _context.Students
                .Include(s => s.Fixtures)
                    .ThenInclude(f => f.Sport)
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.StudentID == id);

            if (Student == null)
            {
                return NotFound();
            }

            return Page();
        }
    }
}


