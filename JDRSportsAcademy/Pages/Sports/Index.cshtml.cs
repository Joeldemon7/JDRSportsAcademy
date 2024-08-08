using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using JDRSportsAcademy.Data;
using JDRSportsAcademy.Models;

namespace JDRSportsAcademy.Pages.Sports
{
    public class IndexModel : PageModel
    {
        private readonly SportContext _context;

        public IndexModel(SportContext context)
        {
            _context = context;
        }

        public IList<Sport> Sport { get; private set; } = default!;

        public async Task OnGetAsync()
        {
            // Fetch the list of sports from the database
            // and store it in the Sport property.
            Sport = await _context.Sports.ToListAsync();
        }
    }
}

