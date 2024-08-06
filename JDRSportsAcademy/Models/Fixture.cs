using System.ComponentModel.DataAnnotations;

namespace JDRSportsAcademy.Models
{
    public class Fixture
    {
        public int FixtureID { get; set; }
        [Required]
        [StringLength(50)]
        [Display(Name = "Fixture Name")]
        public string FixtureName { get; set; }
        public int SportID { get; set; }
        public int StudentID { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime Date { get; set; }
        [DataType(DataType.Time)]
        public DateTime Time { get; set; }
        [Required]
        [StringLength(50)]
        [Display(Name = "Location")]
        public string Location { get; set; }

        public Sport Sport { get; set; }
        public Student Student { get; set; }
    }
}

