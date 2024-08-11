using JDRSportsAcademy.Data;
using JDRSportsAcademy.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JDRSportsAcademy.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly SportContext _context;

        public IndexModel(ILogger<IndexModel> logger, SportContext context)
        {
            _logger = logger;
            _context = context;
        }

        [BindProperty]
        public string FeedbackName { get; set; }

        [BindProperty]
        public string FeedbackEmail { get; set; }

        [BindProperty]
        public string FeedbackMessage { get; set; }

        public bool IsFeedbackSubmitted { get; set; }
        public IList<Feedback> FeedbackList { get; private set; }

        public async Task OnGetAsync()
        {
            FeedbackList = await _context.Feedbacks
                .OrderByDescending(f => f.SubmittedOn)
                .ToListAsync();

            IsFeedbackSubmitted = false;
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (ModelState.IsValid)
            {
                var feedback = new Feedback
                {
                    Name = FeedbackName,
                    Email = FeedbackEmail,
                    Message = FeedbackMessage
                };

                _context.Feedbacks.Add(feedback);
                await _context.SaveChangesAsync();

                IsFeedbackSubmitted = true;

                // Reload the feedback list to show the latest submission
                FeedbackList = await _context.Feedbacks
                    .OrderByDescending(f => f.SubmittedOn)
                    .ToListAsync();

                return Page();
            }

            // If the form is not valid, re-display it with validation messages.
            FeedbackList = await _context.Feedbacks
                .OrderByDescending(f => f.SubmittedOn)
                .ToListAsync();

            return Page();
        }
    }
}

