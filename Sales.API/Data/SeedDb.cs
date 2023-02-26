using Sales.Shared.Entities;

namespace Sales.API.Data
{
    public class SeedDb
    {
        private readonly DataContext _context;

        public SeedDb(DataContext context)
        {
            _context = context;
        }

        public async Task SeedAsync()
        {
            //Este método me hace el update a la base de Datos
            await _context.Database.EnsureCreatedAsync();
            await CheckCountriesAsync();
        }

        private async Task CheckCountriesAsync()
        {
            //El método Any devuelve True si por lo menos hay 1 registros
            if (!_context.Countries.Any())
            {
                _context.Countries.Add(new Country { Name="Colombia"});
                _context.Countries.Add(new Country { Name = "Venezuela" });
                _context.Countries.Add(new Country { Name = "Ecuador" });
                _context.Countries.Add(new Country { Name = "Brazil" });
                _context.Countries.Add(new Country { Name = "Mexico" });
                await _context.SaveChangesAsync();
            }
        }
    }
}
