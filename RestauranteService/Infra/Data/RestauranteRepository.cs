using RestauranteService.Core.Interfaces.Repository;
using RestauranteService.Core.Models;

namespace RestauranteService.Infra.Data;

public class RestauranteRepository : IRestauranteRepository
{
    private readonly AppDbContext _context;

    public RestauranteRepository(AppDbContext context)
    {
        _context = context;
    }

    public void CreateRestaurante(Restaurante restaurante)
    {
        if (restaurante == null)
        {
            throw new ArgumentNullException(nameof(restaurante));
        }

        _context.Restaurantes.Add(restaurante);
    }

    public IEnumerable<Restaurante> GetAllRestaurantes()
    {
        Console.WriteLine("Cheguei no Repositorio - GetAllRestaurantes");
        return _context.Restaurantes.ToList();
    }

    public Restaurante GetRestauranteById(int id) => _context.Restaurantes.FirstOrDefault(c => c.Id == id);

    public void SaveChanges()
    {
        _context.SaveChanges();
    }
}