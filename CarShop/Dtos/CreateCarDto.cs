using CarShop.Entityes;
using System.ComponentModel.DataAnnotations;

namespace CarShop.Dtos
{
    public class CreateCarDto
    {
        [Required(ErrorMessage = "Brand is Required")]
        [StringLength(50, ErrorMessage = "Brand must be at most 50 characters")]
        public string Brand { get; set; }

        [Required(ErrorMessage = "Model is Required")]
        [StringLength(50, ErrorMessage = "Model must be at most 50 characters")]
        public string Model { get; set; }

        [Range(1950,2026, ErrorMessage = "Year must be between 1950 and 2026")]
        public int Year { get; set; }

        [Range(0,1000000, ErrorMessage = "Price must be between 0 and 1 000 000 $")]
        public decimal Price { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "Color must be at most 50 characters")]
        public string Color { get; set; }

        public int CategoryId { get; set; }
       
    }
}
