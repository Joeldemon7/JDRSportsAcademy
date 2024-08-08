using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using JDRSportsAcademy.Data;
using JDRSportsAcademy.Models;

namespace JDRSportsAcademy.Pages.Students
{
    public class CreateModel : PageModel
    {
        private readonly SportContext _context;

        public CreateModel(SportContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Student Student { get; set; } = new Student();

        public IActionResult OnGet()
        {
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Students.Add(Student);

            try
            {
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }
            catch
            {
                ModelState.AddModelError(string.Empty, "An error occurred while saving the student. Please try again.");
                return Page();
            }
        }
    }
}

