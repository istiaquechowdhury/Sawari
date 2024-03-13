using System.ComponentModel.DataAnnotations;

namespace SawariwebRazor.Models
{
    public class Category
    {

        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Range(1, 100, ErrorMessage = "Value must be between 1 and 100")]
        public int DisplayOrder { get; set; }
    }
}
