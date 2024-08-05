﻿using System;
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
    public class DetailsModel : PageModel
    {
        private readonly JDRSportsAcademy.Data.SportContext _context;

        public DetailsModel(JDRSportsAcademy.Data.SportContext context)
        {
            _context = context;
        }

      public Sport Sport { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Sports == null)
            {
                return NotFound();
            }

            var sport = await _context.Sports.FirstOrDefaultAsync(m => m.SportID == id);
            if (sport == null)
            {
                return NotFound();
            }
            else 
            {
                Sport = sport;
            }
            return Page();
        }
    }
}
