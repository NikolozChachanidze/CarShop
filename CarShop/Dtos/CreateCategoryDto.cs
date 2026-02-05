using CarShop.Entityes;
using System.ComponentModel.DataAnnotations;

namespace CarShop.Dtos
{
    public class CreateCategoryDto
    {
        [Required]
        [StringLength(100,ErrorMessage = ("Name too long"))]
        public string Name { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
