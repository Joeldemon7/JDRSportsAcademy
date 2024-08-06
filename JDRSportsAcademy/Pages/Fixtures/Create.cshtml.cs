using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using JDRSportsAcademy.Data;
using JDRSportsAcademy.Models;

namespace JDRSportsAcademy.Pages.Fixtures
{
    public class CreateModel : PageModel
    {
        private readonly JDRSportsAcademy.Data.SportContext _context;

        public CreateModel(JDRSportsAcademy.Data.SportContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["SportID"] = new SelectList(_context.Sports, "SportID", "SportName");
        ViewData["StudentID"] = new SelectList(_context.Students, "StudentID", "FullName");
            return Page();
        }

        [BindProperty]
        public Fixture Fixture { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Fixtures == null || Fixture == null)
            {
                return Page();
            }

            _context.Fixtures.Add(Fixture);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
