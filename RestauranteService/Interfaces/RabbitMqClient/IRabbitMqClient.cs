using RestauranteService.Dtos;

namespace RestauranteService.Interfaces.RabbitMqClient
{
	public interface IRabbitMqClient
	{
		void PublicarRestaurante(RestauranteReadDto restauranteReadDto);
	}
}
