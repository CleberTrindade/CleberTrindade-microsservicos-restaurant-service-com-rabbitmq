using RestauranteService.Core.Models;

namespace RestauranteService.Core.Interfaces.Repository;

public interface IRestauranteRepository
{
    void SaveChanges();

    IEnumerable<Restaurante> GetAllRestaurantes();
    Restaurante GetRestauranteById(int id);
    void CreateRestaurante(Restaurante restaurante);
}
