using AutoMapper;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Globalization;
using Virtual_Wallet.Models.Dtos;
using Virtual_Wallet.Models.ViewModels;
using Virtual_Wallet.VirtualWallet.API.Models.Dtos;
using Virtual_Wallet.VirtualWallet.Domain.Entities;

namespace Virtual_Wallet.VirtualWallet.API.Helpers.Mappers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Card Mapping
            CreateMap<CardAddDto, Card>()
                .ForMember(dest => dest.ExpirationDate, opts => opts.MapFrom(src => DateTime.ParseExact(src.ExpireDateFormatted, "MMyy", CultureInfo.InvariantCulture)));
            CreateMap<Card, CardAddDto>();
            CreateMap<CardShowDto, Card>();
            CreateMap<Card, CardShowDto>();
            CreateMap<CardUpdateViewModel, Card>()
                .ForMember(dest => dest.ExpirationDate, opts => opts.MapFrom(src => DateTime.ParseExact(src.ExpireDateFormatted, "MMyy", CultureInfo.InvariantCulture)))
                .ForMember(dest => dest.IsCreditCard, opts => opts.MapFrom(src => src.IsCreditCard));

			//Transactions Mapping
			CreateMap<Transaction, TransactionShowDto>()
                .ForMember(dto => dto.Date, opt => opt.MapFrom(date => date.Date.ToString("yyyy-MM-dd HH:mm:ss")));
			CreateMap<TransactionShowDto, Transaction>();
			CreateMap<Transaction, MakeCardTransactionViewModel>()
	                .ForMember(dto => dto.Cards, opt => opt.Ignore());
			CreateMap<MakeCardTransactionViewModel, Transaction>();
			CreateMap<Transaction, TransactionViewModel>();

			//User mappings
			CreateMap<User, UserShowDto>();
			CreateMap<UserLoginDto, User>()
                .ForMember(dest => dest.Username, opts => opts.MapFrom(src => src.Username))
                .ForMember(dest => dest.Password, opts => opts.MapFrom(src => src.Password));

            CreateMap<UserRegisterDto, User>()
                .ForMember(dest => dest.Username, opts => opts.MapFrom(src => src.Username))
                .ForMember(dest => dest.Email, opts => opts.MapFrom(src => src.Email))
                .ForMember(dest => dest.Password, opts => opts.MapFrom(src => src.Password));

            // Wallet Mapping
            CreateMap<WalletCreateUpdateDto, Wallet>();
        }
    }
}
