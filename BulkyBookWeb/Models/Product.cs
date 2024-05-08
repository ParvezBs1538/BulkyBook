using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace BulkyBookWeb.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        [Range(1, 100, ErrorMessage = "Order must be between 1 to 100")] 
        public int Quantity { get; set; }
        [Required]
        public int Price { get; set; }
    }
}
