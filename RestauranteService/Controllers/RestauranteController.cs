using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RestauranteService.Application.Dtos;
using RestauranteService.Core.Interfaces.Repository;
using RestauranteService.Core.Interfaces.Services;
using RestauranteService.Core.Models;

namespace RestauranteService.Controllers;

[Route("api/[controller]")]
[ApiController]
public class RestauranteController : ControllerBase
{
    private readonly IRestauranteRepository _repository;
    private readonly IMapper _mapper;
    private IItemServiceHttpClient _itemServiceHttpClient;
	private IRabbitMqClient _rabbitMqClient;

	public RestauranteController(
		IRestauranteRepository repository,
		IMapper mapper,
		IItemServiceHttpClient itemServiceHttpClient,
		IRabbitMqClient rabbitMqClient)
	{
		_repository = repository;
		_mapper = mapper;
		_itemServiceHttpClient = itemServiceHttpClient;
		_rabbitMqClient = rabbitMqClient;
	}

	[HttpGet]
    public ActionResult<IEnumerable<RestauranteReadDto>> GetAllRestaurantes()
    {
		Console.WriteLine("Cheguei na controller");
		var restaurantes = _repository.GetAllRestaurantes();

        return Ok(_mapper.Map<IEnumerable<RestauranteReadDto>>(restaurantes));
    }

    [HttpGet("{id}", Name = "GetRestauranteById")]
    public ActionResult<RestauranteReadDto> GetRestauranteById(int id)
    {
        var restaurante = _repository.GetRestauranteById(id);
        if (restaurante != null)
        {
            return Ok(_mapper.Map<RestauranteReadDto>(restaurante));
        }

        return NotFound();
    }

    [HttpPost]
    public async Task<ActionResult<RestauranteReadDto>> CreateRestaurante(RestauranteCreateDto restauranteCreateDto)
    {
        var restaurante = _mapper.Map<Restaurante>(restauranteCreateDto);
        _repository.CreateRestaurante(restaurante);
        _repository.SaveChanges();

        var restauranteReadDto = _mapper.Map<RestauranteReadDto>(restaurante);

        //Comunicação síncrona
        //_itemServiceHttpClient.EnviaRestauranteParaItemService(restauranteReadDto);

        //Comunicação Assíncrona
        _rabbitMqClient.PublicarRestaurante(restauranteReadDto);

        return CreatedAtRoute(nameof(GetRestauranteById), new { restauranteReadDto.Id }, restauranteReadDto);
    }
}
