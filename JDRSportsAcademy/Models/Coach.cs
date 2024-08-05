using System.ComponentModel.DataAnnotations;

namespace JDRSportsAcademy.Models
{
    public class Coach
    {
        public int CoachID { get; set; }
        public int SportID { get; set; }
        public string CoachName { get; set; }
        public string CoachNumber { get; set; }
        [DataType(DataType.EmailAddress)]
        public string CoachEmail { get; set; }

        public Sport Sport { get; set; }
    }
}
