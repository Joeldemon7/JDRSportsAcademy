using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using JDRSportsAcademy.Models.SportViewModels;
using JDRSportsAcademy.Data;

namespace JDRSportsAcademy.Pages
{
    public class AboutModel : PageModel
    {
        private readonly SportContext _context;

        public AboutModel(SportContext context)
        {
            _context = context;
        }

        public IList<FixtureDateGroup> Fixtures { get; set; }

        public async Task OnGetAsync()
        {
            var data = from fixture in _context.Fixtures
                       group fixture by fixture.Date into dateGroup
                       select new FixtureDateGroup
                       {
                           FixtureDate = dateGroup.Key,
                           StudentCount = dateGroup.Count()
                       };

            Fixtures = await data.AsNoTracking().ToListAsync();
        }
    }
}

