using RestauranteService.Application.Dtos;
using RestauranteService.Core.Interfaces.Services;
using System.Text;
using System.Text.Json;

namespace RestauranteService.Application.Services.ItemServiceHttpClient
{
    public class ItemServiceHttpClient : IItemServiceHttpClient
    {
        private readonly HttpClient _client;
        private readonly IConfiguration _configuration;
        public ItemServiceHttpClient(HttpClient client, IConfiguration configuration)
        {
            _client = client;
            _configuration = configuration;
        }



        public async void EnviaRestauranteParaItemService(RestauranteReadDto restauranteReadDto)
        {
            var conteudoHttp = new StringContent
                (
                    JsonSerializer.Serialize(restauranteReadDto),
                    Encoding.UTF8,
                    "application/json"
                );
            //Cominucação sincrona.
            await _client.PostAsync(_configuration["ItemService"], conteudoHttp);
        }
    }
}
