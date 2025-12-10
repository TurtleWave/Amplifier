using Amplifier.WareHouse.Core.DTO;
using AutoMapper;

namespace Amplifier.WareHouse.Core.Mappers;

public class AutoMappingProfile: Profile
{
    public AutoMappingProfile()
    {
        CreateMap<CostDTO, Cost>().ReverseMap();
        CreateMap<ProductDTO, Product>().ReverseMap();
        CreateMap<SupplyDTO, Supply>().ReverseMap();
    }
}