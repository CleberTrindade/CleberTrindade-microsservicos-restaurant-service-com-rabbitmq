using RestauranteService.Application.Dtos;

namespace RestauranteService.Core.Interfaces.Services;

public interface IItemServiceHttpClient
{
    public void EnviaRestauranteParaItemService(RestauranteReadDto restauranteReadDto);
}
