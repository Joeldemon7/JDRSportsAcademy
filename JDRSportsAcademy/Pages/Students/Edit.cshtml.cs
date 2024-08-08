using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using JDRSportsAcademy.Data;
using JDRSportsAcademy.Models;
using Microsoft.Extensions.Logging;

namespace JDRSportsAcademy.Pages.Students
{
    public class EditModel : PageModel
    {
        private readonly SportContext _context;
        private readonly ILogger<EditModel> _logger;

        public EditModel(SportContext context, ILogger<EditModel> logger)
        {
            _context = context;
            _logger = logger;
        }

        [BindProperty]
        public Student Student { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                _logger.LogWarning("Edit page accessed with null ID.");
                return NotFound("Student ID not provided.");
            }

            Student = await _context.Students.FindAsync(id);

            if (Student == null)
            {
                _logger.LogWarning("Student with ID {Id} not found.", id);
                return NotFound("Student not found.");
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int id)
        {
            var studentToUpdate = await _context.Students.FindAsync(id);

            if (studentToUpdate == null)
            {
                _logger.LogWarning("Failed to update student. Student with ID {Id} not found.", id);
                return NotFound("Student not found.");
            }

            if (await TryUpdateModelAsync(
                studentToUpdate,
                "student",
                s => s.FirstName, s => s.LastName, s => s.DOB, s => s.Gender, s => s.Address, s => s.ContactNumber, s => s.MedicalInformation, s => s.Email))
            {
                try
                {
                    await _context.SaveChangesAsync();
                    return RedirectToPage("./Index");
                }
                catch (DbUpdateException ex)
                {
                    _logger.LogError(ex, "Error updating student with ID {Id}.", id);
                    ModelState.AddModelError(string.Empty, "Unable to save changes. Try again, and if the problem persists see your system administrator.");
                }
            }

            return Page();
        }

        private bool StudentExists(int id)
        {
            return _context.Students.Any(e => e.StudentID == id);
        }
    }
}

