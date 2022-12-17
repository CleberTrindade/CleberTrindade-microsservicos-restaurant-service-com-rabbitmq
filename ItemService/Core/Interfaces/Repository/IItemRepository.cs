using System.Collections.Generic;
using ItemService.Core.Models;

namespace ItemService.Core.Interfaces.Repository;

public interface IItemRepository
{
    void SaveChanges();

    IEnumerable<Restaurante> GetAllRestaurantes();
    void CreateRestaurante(Restaurante restaurante);
    bool RestauranteExiste(int restauranteId);
    bool ExisteRestauranteExterno(int restauranteIdExterno);

    IEnumerable<Item> GetItensDeRestaurante(int restauranteId);
    Item GetItem(int restauranteId, int itemId);
    void CreateItem(int restauranteId, Item item);
}
