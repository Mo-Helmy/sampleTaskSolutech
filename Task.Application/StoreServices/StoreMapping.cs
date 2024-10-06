using AutoMapper;
using Task.Application.StoreServices.Dto;
using Task.Domain.Entities;

namespace Task.Application.StoreServices;

public class StoreMapping : Profile
{
    public StoreMapping()
    {
        CreateMap<Store, StoreDetailsResponseDto>().ReverseMap();
        CreateMap<AddStoreCommandDto, Store>()
            .ForMember(x => x.Spaces, opt => opt.MapFrom(src => new List<StoreSpace>() { new StoreSpace() { IsDefault = true, Name = "Default Space"} }));

        CreateMap<EditStoreCommandDto, Store>();
    }
}
