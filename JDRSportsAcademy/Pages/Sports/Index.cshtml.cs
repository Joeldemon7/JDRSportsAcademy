using System.Collections.Generic;
using System.Linq;
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
        public string? SearchString { get; set; }

        public async Task OnGetAsync(string? searchString)
        {
            SearchString = searchString;

            IQueryable<Sport> sportsQuery = _context.Sports;

            if (!string.IsNullOrEmpty(searchString))
            {
                sportsQuery = sportsQuery.Where(s => s.SportName.Contains(searchString));
            }

            Sport = await sportsQuery.ToListAsync();
        }
    }
}


