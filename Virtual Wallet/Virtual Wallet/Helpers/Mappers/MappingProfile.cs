using AutoMapper;
using System.Globalization;
using Virtual_Wallet.VirtualWallet.API.Models.Dtos;
using Virtual_Wallet.VirtualWallet.Domain.Entities;

namespace Virtual_Wallet.VirtualWallet.API.Helpers.Mappers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CardAddDto, Card>()
                .ForMember(dest => dest.ExpirationDate, opts => opts.MapFrom(src => DateTime.ParseExact(src.ExpireDateFormatted, "MMyy", CultureInfo.InvariantCulture)));
            CreateMap<Card, CardAddDto>();

            CreateMap<CardShowDto, Card>();
            CreateMap<Card, CardShowDto>();
        }
    }
}
