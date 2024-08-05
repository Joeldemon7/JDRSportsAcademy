﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using JDRSportsAcademy.Data;
using JDRSportsAcademy.Models;

namespace JDRSportsAcademy.Pages.Coaches
{
    public class IndexModel : PageModel
    {
        private readonly JDRSportsAcademy.Data.SportContext _context;

        public IndexModel(JDRSportsAcademy.Data.SportContext context)
        {
            _context = context;
        }

        public IList<Coach> Coach { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Coaches != null)
            {
                Coach = await _context.Coaches
                .Include(c => c.Sport).ToListAsync();
            }
        }
    }
}