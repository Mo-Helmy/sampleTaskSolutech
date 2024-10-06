using AutoMapper;
using Task.Application.StoreServices.Dto;
using Task.Domain.Entities;

namespace Task.Application.StoreServices;

public class StoreMapping : Profile
{
    public StoreMapping()
    {
        CreateMap<Store, StoreResponseDto>().ReverseMap();
        CreateMap<Store, StoreDetailsResponseDto>()
            .ForMember(x => x.Spaces, opt => opt.MapFrom(src => src.Spaces))
            .ReverseMap();

        CreateMap<AddStoreCommandDto, Store>()
            .ForMember(x => x.Spaces, opt => opt.MapFrom(src => new List<StoreSpace>() { new StoreSpace() { Name = "Default Space"} }));

        CreateMap<EditStoreCommandDto, Store>();


        CreateMap<StoreSpace, StoreSpaceResponseDto>().ReverseMap();
        CreateMap<StoreSpace, StoreSpaceDetailsResponseDto>()
            .ForMember(x => x.Store, opt => opt.MapFrom(src => src.Store))
            .ReverseMap();

        CreateMap<Product, ProductResponseDto>().ReverseMap();
    }
}
