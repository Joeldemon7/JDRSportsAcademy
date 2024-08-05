using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using JDRSportsAcademy.Data;
using JDRSportsAcademy.Models;

namespace JDRSportsAcademy.Pages.Sports
{
    public class IndexModel : PageModel
    {
        private readonly JDRSportsAcademy.Data.SportContext _context;

        public IndexModel(JDRSportsAcademy.Data.SportContext context)
        {
            _context = context;
        }

        public IList<Sport> Sport { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Sports != null)
            {
                Sport = await _context.Sports.ToListAsync();
            }
        }
    }
}
