using System.ComponentModel.DataAnnotations;

namespace deml.Models
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }
        [Required]
        public string name { get; set; }
        [Range(1, 100, ErrorMessage = "must be btw 1-100")]
        public int DisplayOrder { get; set; }
    }
}
