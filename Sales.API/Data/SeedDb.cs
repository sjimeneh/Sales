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
            await CheckCategoriesAsync();
        }

        private async Task CheckCategoriesAsync()
        {
            if (!_context.Categories.Any())
            {
                _context.Categories.Add(new Category { Name = "Belleza" });
                _context.Categories.Add(new Category { Name = "Hogar" });
                _context.Categories.Add(new Category { Name = "Moda" });
                _context.Categories.Add(new Category { Name = "Tecnología" });
                _context.Categories.Add(new Category { Name = "Calzado" });
                _context.Categories.Add(new Category { Name = "Deporte" });
                _context.Categories.Add(new Category { Name = "Juguetería" });
                _context.Categories.Add(new Category { Name = "Cocina" });
                _context.Categories.Add(new Category { Name = "Video Juegos" });
                _context.Categories.Add(new Category { Name = "Entretenimiento" });
                
                await _context.SaveChangesAsync();
            }
        }

        private async Task CheckCountriesAsync()
        {
            //El método Any devuelve True si por lo menos hay 1 registros
            if (!_context.Countries.Any())
            {
                _context.Countries.Add(new Country
                {
                    Name = "Colombia",
                    States = new List<State>
                    {
                        new State {
                            Name="Antioquia",
                            Cities = new List<City>{
                               new City{Name="Medellin"},
                               new City{Name="Bello"},
                               new City{Name="Envigado"},
                               new City{Name="Itagui"},
                            }
                        },
                        new State {
                            Name="Cundinamarca",
                            Cities = new List<City>{
                                new City { Name="Bogota"},
                                new City { Name="Soacha"},
                                new City { Name="Girardot"},
                                new City { Name="Pacho"}
                            }
                        },
                        new State {
                            Name="Choco",
                            Cities = new List < City > {
                                new City { Name = "Ancandí" },
                                new City { Name = "Condoto" },
                                new City { Name = "Lloro" },
                                new City { Name = "Sipi" }
                            }},
                        new State {Name="Huila"},
                        new State {Name="Norte de Santander"}
                    }
                });

                _context.Countries.Add(new Country
                {
                    Name = "Estados Unidos",
                    States = new List<State>()
                    {
                new State()
                {
                    Name = "Florida",
                    Cities = new List<City>() {
                        new City() { Name = "Orlando" },
                        new City() { Name = "Miami" },
                        new City() { Name = "Tampa" },
                        new City() { Name = "Fort Lauderdale" },
                        new City() { Name = "Key West" },
                    }
                },
                new State()
                {
                    Name = "Texas",
                    Cities = new List<City>() {
                        new City() { Name = "Houston" },
                        new City() { Name = "San Antonio" },
                        new City() { Name = "Dallas" },
                        new City() { Name = "Austin" },
                        new City() { Name = "El Paso" },
                    }
                },
            }
                });




                _context.Countries.Add(new Country { Name = "Venezuela" });
                _context.Countries.Add(new Country { Name = "Ecuador" });
                _context.Countries.Add(new Country { Name = "Brazil" });
                _context.Countries.Add(new Country { Name = "Mexico" });

                await _context.SaveChangesAsync();
            }
        }
    }
}
