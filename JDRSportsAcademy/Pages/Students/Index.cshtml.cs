using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using JDRSportsAcademy.Data;
using JDRSportsAcademy.Models;
using JDRSportsAcademy.Helpers;

namespace JDRSportsAcademy.Pages.Students
{
    public class IndexModel : PageModel
    {
        private readonly SportContext _context;
        private readonly int _pageSize;

        public IndexModel(SportContext context, IConfiguration configuration)
        {
            _context = context;
            _pageSize = configuration.GetValue<int>("PageSize", 4);
        }

        public PaginatedList<Student> Student { get; set; } = default!;
        public string NameSort { get; set; } = default!;
        public string LastNameSort { get; set; } = default!;
        public string DateSort { get; set; } = default!;
        public string CurrentSort { get; set; } = default!;
        public string CurrentFilter { get; set; } = default!;

        public async Task OnGetAsync(string sortOrder, string currentFilter, string searchString, int? pageIndex)
        {
            CurrentSort = sortOrder;
            NameSort = string.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
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

            IQueryable<Student> studentsIQ = _context.Students.AsQueryable();

            if (!string.IsNullOrEmpty(searchString))
            {
                studentsIQ = studentsIQ.Where(s => s.FirstName.Contains(searchString) || s.LastName.Contains(searchString));
            }

            studentsIQ = sortOrder switch
            {
                "name_desc" => studentsIQ.OrderByDescending(s => s.FirstName),
                "LastName" => studentsIQ.OrderBy(s => s.LastName),
                "lastname_desc" => studentsIQ.OrderByDescending(s => s.LastName),
                "Date" => studentsIQ.OrderBy(s => s.DOB),
                "date_desc" => studentsIQ.OrderByDescending(s => s.DOB),
                _ => studentsIQ.OrderBy(s => s.FirstName),
            };

            Student = await PaginatedList<Student>.CreateAsync(
                studentsIQ.AsNoTracking(), pageIndex ?? 1, _pageSize);
        }
    }
}


