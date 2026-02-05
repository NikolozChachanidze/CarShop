using System.ComponentModel.DataAnnotations;

namespace CarShop.Dtos
{
    public class UpdateCategoryDto
    {
        [Required]
        [StringLength(100, ErrorMessage = ("Name too long"))]
        public string Name { get; set; }
    }
}
