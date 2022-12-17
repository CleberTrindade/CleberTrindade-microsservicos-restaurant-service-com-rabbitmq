using RestauranteService.Application.Dtos;

namespace RestauranteService.Core.Interfaces.Services
{
    public interface IRabbitMqClient
    {
        void PublicarRestaurante(RestauranteReadDto restauranteReadDto);
    }
}
