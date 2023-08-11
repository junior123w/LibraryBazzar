using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace LibraryBazzar.Models
{
    public class Book
    {

        [Key]
        public int BookId { get; set; }
        
        [Required, MaxLength(100)]
        public string Title { get; set; }
        [MaxLength(100)]
        public string? Author { get; set; }
        [MaxLength(50)]
        public string? Genre { get; set; }
        [MaxLength(1000)]
        public string? Synopsis { get; set; }
        [Required]
        [DataType(DataType.Currency)]
        [Range(0.01, double.MaxValue, ErrorMessage = "Price must be greater than 0.")]
        public decimal Price { get; set; }

        //Child referernce
        public List<Review>? Review { get; set; }
    }
}
