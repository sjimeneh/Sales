using System.ComponentModel.DataAnnotations;

namespace Sales.Shared.Entities
{
    public class Country
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [MaxLength(100, ErrorMessage = "El campo {0} debe tener por lo menos 100 carácteres")]
        [Display(Name = "País")]
        public string Name { get; set; } = null!;

        public ICollection<State>? States { get; set; }

        public int StatesNumber => States == null ? 0 : States.Count();
    }
}
