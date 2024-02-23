using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mission06_Eyre.Models
{// For each column, create a get; set;. Make MovieID the key, and title/year/rating/edited/copytoplex required.
    public class Movie
    {
        [Key]
        public int MovieId { get; set; }

        [ForeignKey("Category")]
        public int? CategoryId { get; set; }
        public Category? Category { get; set; }

        [Required(ErrorMessage = "Title is required")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Year is required")]
        [Range(1888, int.MaxValue, ErrorMessage = "Year must be 1888 or later")]
        public int Year { get; set; }

        public string? Director { get; set; }

        [Required(ErrorMessage = "Rating is required")]
        public string Rating { get; set; }

        [Required(ErrorMessage = "Edited is required")]
        public bool Edited { get; set; }

        public string? LentTo { get; set; }

        [Required(ErrorMessage = "CopiedToPlex is required")]
        public bool CopiedToPlex { get; set; }

        public string? Notes { get; set; }
    }
}
