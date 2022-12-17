using AutoMapper;
using ItemService.Application.Dtos;
using ItemService.Core.Models;

namespace ItemService.Application.Profiles;

public class ItemProfile : Profile
{
    public ItemProfile()
    {
        CreateMap<RestauranteReadDto, Restaurante>()
            .ForMember(dest => dest.IdExterno, opt => opt.MapFrom(src => src.Id));
        CreateMap<Restaurante, RestauranteReadDto>();
        CreateMap<ItemCreateDto, Item>();
        CreateMap<Item, ItemCreateDto>();
    }
}