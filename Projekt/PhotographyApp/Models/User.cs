using System.ComponentModel.DataAnnotations;

namespace PhotographyApp.Models
{
    public class User
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "User Name")]
        public string UserName { get; set; } = string.Empty;  // Tilldela standardvärde eller använd required

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; } = string.Empty;  // Tilldela standardvärde eller använd required

        public string Role { get; set; } = "Photographer";
    }
}
