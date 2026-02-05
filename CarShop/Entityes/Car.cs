using System.ComponentModel.DataAnnotations;

namespace CarShop.Entityes
{
    public class Car
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Brand is Required")]
        [StringLength(50, ErrorMessage = "Brand name too long")]
        public string Brand { get; set; }

        [Required(ErrorMessage = "Model is required")]
        [StringLength(50, ErrorMessage = "Brand name too long")]
        public string Model { get; set; }

        [Range(1950,2026, ErrorMessage = "Year must be between 1950 and 2026")]
        public int Year { get; set; }

        [Range(0,1000000, ErrorMessage = "Price must be between 0 and 1000000$")]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "Color is Required")]
        [StringLength(50, ErrorMessage = "Color too long")]
        public string Color { get; set; }
        public bool IsAvailable { get; set; }
        public int? CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
