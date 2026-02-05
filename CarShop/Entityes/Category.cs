using System.ComponentModel.DataAnnotations;

namespace CarShop.Entityes
{
    public class Category
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "Name must be less than 100 symbols")]
        public string Name { get; set; }
        public ICollection<Car> Cars { get; set; } = new List<Car>();
    }
}
