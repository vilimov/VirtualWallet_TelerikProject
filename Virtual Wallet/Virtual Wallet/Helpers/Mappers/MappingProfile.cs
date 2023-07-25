using AutoMapper;
using Virtual_Wallet.VirtualWallet.API.Models.Dtos;
using Virtual_Wallet.VirtualWallet.Domain.Entities;

namespace Virtual_Wallet.VirtualWallet.API.Helpers.Mappers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CardAddDto, Card>();
            CreateMap<Card, CardAddDto>();

            CreateMap<CardShowDto, Card>();
            CreateMap<Card, CardShowDto>();
        }
    }
}
