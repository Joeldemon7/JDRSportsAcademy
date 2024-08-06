using System.ComponentModel.DataAnnotations;

namespace JDRSportsAcademy.Models
{
    public class Coach
    {
        public int CoachID { get; set; }
        public int SportID { get; set; }
        [Required]
        [StringLength(50)]
        [Display(Name = "Coach Name")]
        public string CoachName { get; set; }
        [Required]
        [DataType(DataType.PhoneNumber)]
        [StringLength(15)]
        [Display(Name = "Coach Number")]
        public string CoachNumber { get; set; }
        [Required]
        [StringLength(50)]
        [Display(Name = "Coach Email")]
        [DataType(DataType.EmailAddress)]
        public string CoachEmail { get; set; }

        public Sport Sport { get; set; }
    }
}
