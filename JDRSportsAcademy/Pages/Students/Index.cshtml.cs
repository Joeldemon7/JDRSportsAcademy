using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using JDRSportsAcademy.Data;
using JDRSportsAcademy.Helpers;
using JDRSportsAcademy.Models;

namespace JDRSportsAcademy.Pages.Students
{
    public class IndexModel : PageModel
    {
        private readonly JDRSportsAcademy.Data.SportContext _context;
        private readonly IConfiguration _configuration;

        public IndexModel(JDRSportsAcademy.Data.SportContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        public PaginatedList<Student> Student { get; set; } = default!;
        public string NameSort { get; set; } = default!;
        public string LastNameSort { get; set; } = default!;
        public string DateSort { get; set; } = default!;
        public string CurrentSort { get; set; } = default!;
        public string SearchString { get; set; } = default!;
        public string CurrentFilter { get; set; } = default!;

        public async Task OnGetAsync(string sortOrder, string currentFilter, string searchString, int? pageIndex)
        {
            CurrentSort = sortOrder;
            NameSort = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            LastNameSort = sortOrder == "LastName" ? "lastname_desc" : "LastName";
            DateSort = sortOrder == "Date" ? "date_desc" : "Date";

            if (searchString != null)
            {
                pageIndex = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            CurrentFilter = searchString;

            IQueryable<Student> studentsIQ = from s in _context.Students
                                             select s;

            if (!String.IsNullOrEmpty(searchString))
            {
                studentsIQ = studentsIQ.Where(s => s.FirstName.Contains(searchString)
                                       || s.LastName.Contains(searchString));
            }

            switch (sortOrder)
            {
                case "name_desc":
                    studentsIQ = studentsIQ.OrderByDescending(s => s.FirstName);
                    break;
                case "LastName":
                    studentsIQ = studentsIQ.OrderBy(s => s.LastName);
                    break;
                case "lastname_desc":
                    studentsIQ = studentsIQ.OrderByDescending(s => s.LastName);
                    break;
                case "Date":
                    studentsIQ = studentsIQ.OrderBy(s => s.DOB);
                    break;
                case "date_desc":
                    studentsIQ = studentsIQ.OrderByDescending(s => s.DOB);
                    break;
                default:
                    studentsIQ = studentsIQ.OrderBy(s => s.FirstName);
                    break;
            }

            var pageSize = _configuration.GetValue<int>("PageSize",4);
            Student = await PaginatedList<Student>.CreateAsync(
                studentsIQ.AsNoTracking(), pageIndex ?? 1, pageSize);
        }
    }
}

