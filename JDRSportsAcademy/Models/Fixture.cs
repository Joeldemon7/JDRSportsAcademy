using System.ComponentModel.DataAnnotations;

namespace JDRSportsAcademy.Models
{
    public class Fixture
    {
        public int FixtureID { get; set; }
        public string FixtureName { get; set; }
        public int SportID { get; set; }
        public int StudentID { get; set; }
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }
        [DataType(DataType.Time)]
        public DateTime Time { get; set; }
        public string Location { get; set; }

        public Sport Sport { get; set; }
        public Student Student { get; set; }
    }
}

