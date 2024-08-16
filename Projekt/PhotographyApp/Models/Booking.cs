using System;
using System.ComponentModel.DataAnnotations;

namespace PhotographyApp.Models
{
    public class Booking
    {
        public int Id { get; set; }

        [Required]
        public string CustomerName { get; set; } = string.Empty;

        [Required]
        [EmailAddress]
        public string CustomerEmail { get; set; } = string.Empty;

        [Required]
        public DateTime Date { get; set; }

        [Required]
        public int PackageId { get; set; }

        public Package? Package { get; set; }
    }
}
