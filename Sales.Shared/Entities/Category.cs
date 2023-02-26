using System.ComponentModel.DataAnnotations;

namespace Sales.Shared.Entities
{
    public class Category
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "El campo {0} en obligatorio")]
        [MaxLength(100, ErrorMessage = "El campo {0} debe tener por lo menos 100 carácteres")]
        [Display(Name = "Categoría")]
        public string Name { get; set; } = null!;
    }
}
