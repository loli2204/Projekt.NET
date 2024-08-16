using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PhotographyApp.Models
{
    public class Package
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = string.Empty;

        [Required]
        public string Description { get; set; } = string.Empty;

        [Required]
        [DataType(DataType.Currency)]
        public decimal Price { get; set; }

        public List<string> ImagePaths { get; set; } = new List<string>();
        public ICollection<Booking>? Bookings { get; set; }
    
    }
}
