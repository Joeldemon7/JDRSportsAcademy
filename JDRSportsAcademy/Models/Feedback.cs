using System;
using System.ComponentModel.DataAnnotations;

namespace JDRSportsAcademy.Models
{
    public class Feedback
    {
        public int ID { get; set; }

        [StringLength(100)]
        public string Name { get; set; }

        [StringLength(100)]
        public string Email { get; set; }

        [Required]
        public string Message { get; set; }

        [Range(1, 5)]
        public int Rating { get; set; }

        public DateTime SubmittedOn { get; set; } = DateTime.Now;
    }
}