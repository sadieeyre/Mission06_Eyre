using System.ComponentModel.DataAnnotations;

namespace Mission06_Eyre.Models
{
    //Make a class directory with the id and name for each one 
    public class Category
    {
        [Key]
        public int CategoryID { get; set; }
        public string? CategoryName { get; set; }
    }
}
