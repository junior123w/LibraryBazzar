using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibraryBazzar.Models
{
    public class Review
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ReviewId { get; set; }
        //parent refereence
        public int BookId { get; set; }
        [Required, StringLength(50)]
        public string? Title { get; set; }
        [Required , DataType(DataType.Date)]
        public DateTime ReviewDate { get; set; }

        [Required, Range(0, 5)]
        public decimal Rating { get; set; }

        [MaxLength(500)]
        public string? Comments { get; set; }

        //nav refernece
        public Book? Book { get; set; }

    }
}
