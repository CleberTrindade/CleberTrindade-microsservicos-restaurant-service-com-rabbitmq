using AutoMapper;
using RestauranteService.Application.Dtos;
using RestauranteService.Core.Models;

namespace RestauranteService.Application.Profiles
{
    public class RestauranteProfile : Profile
    {
        public RestauranteProfile()
        {
            CreateMap<Restaurante, RestauranteReadDto>();
            CreateMap<RestauranteCreateDto, Restaurante>();
        }
    }
}