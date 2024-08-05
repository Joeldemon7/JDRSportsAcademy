using System;
using System.ComponentModel.DataAnnotations;

namespace JDRSportsAcademy.Models.SportViewModels
{
    public class FixtureDateGroup
    {
        [DataType(DataType.Date)]
        public DateTime? FixtureDate { get; set; }

        public int StudentCount { get; set; }
    }
}

