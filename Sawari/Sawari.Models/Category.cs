using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Sawari.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Range(1, 100, ErrorMessage = "Value must be between 1 and 100")]
        [DisplayName("Display Order")]
        public int DisplayOrder { get; set; }

    }
}
