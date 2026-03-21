using AutoMapper;
using Cambist.Core.Entities;
using Cambist.Core.Models.Requests;
using Cambist.Core.Models.Responses;

namespace Cambist.Infrastructure.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Currency, CurrencyResponse>().ReverseMap();
            CreateMap<ConversionRecord, ConversionRecordResponse>().ReverseMap();
            CreateMap<WatchlistItem, WatchlistItemResponse>().ReverseMap();
            CreateMap<AddWatchlistItemRequest, WatchlistItem>()
                .ForMember(dest => dest.CreatedAt, opt => opt.MapFrom(_ => DateTime.UtcNow));

        }
    }
}
