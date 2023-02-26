using System.ComponentModel.DataAnnotations;

namespace Sales.Shared.Entities
{
    public class State
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [MaxLength(100, ErrorMessage = "El campo {0} solo puede tener {1} carácteres")]
        [Display(Name = "Estado/Departamento")]
        public string Name { get; set; } = null!;

        public Country? Country { get; set; }

        public ICollection<City>? Cities { get; set; }
        public int CitiesNumber => Cities == null? 0 : Cities.Count;
    }
}
