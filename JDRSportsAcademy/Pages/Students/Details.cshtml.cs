using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using JDRSportsAcademy.Data;
using JDRSportsAcademy.Models;

namespace JDRSportsAcademy.Pages.Students
{
    public class DetailsModel : PageModel
    {
        private readonly JDRSportsAcademy.Data.SportContext _context;

        public DetailsModel(JDRSportsAcademy.Data.SportContext context)
        {
            _context = context;
        }

      public Student Student { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Students == null)
            {
                return NotFound();
            }

            Student = await _context.Students
            .Include(s => s.Fixtures)
            .ThenInclude(e => e.Sport)
            .AsNoTracking()
            .FirstOrDefaultAsync(m => m.StudentID == id);

            if (Student == null)
            {
                return NotFound();
            }
            else 
            {
                Student = Student;
            }
            return Page();
        }
    }
}
