using AutoMapper;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
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
                .ForMember(
                     dest => dest.ExpirationDate,
                    opts => opts.MapFrom(src => ParseExpirationDate(src.ExpireDateFormatted)));

			CreateMap<Card, CardAddDto>();
            CreateMap<CardShowDto, Card>();
            CreateMap<Card, CardShowDto>();
            CreateMap<CardUpdateViewModel, Card>()
                .ForMember(
                    dest => dest.ExpirationDate, 
                    opts => opts.MapFrom(src => ParseExpirationDate(src.ExpireDateFormatted)))
                .ForMember(
                    dest => dest.IsCreditCard, 
                    opts => opts.MapFrom(
                        src => src.IsCreditCard));
            CreateMap<Card, CardViewModel>().ReverseMap();

			//Transactions Mapping
			CreateMap<Transaction, TransactionShowDto>()
                .ForMember(
                    dto => dto.Date, 
                    opt => opt.MapFrom( 
                        date => date.Date.ToString("yyyy-MM-dd HH:mm:ss")));
			CreateMap<TransactionShowDto, Transaction>();
			CreateMap<Transaction, MakeCardTransactionViewModel>()
                .ForMember(
                    dto => dto.Cards, 
                    opt => opt.Ignore());
			CreateMap<MakeCardTransactionViewModel, Transaction>();
			CreateMap<Transaction, TransactionViewModel>();

			//User mappings
			CreateMap<User, UserShowDto>();
			CreateMap<UserLoginDto, User>()
                .ForMember(
                    dest => dest.Username, 
                    opts => opts.MapFrom(src => src.Username))
                .ForMember(
                    dest => dest.Password, 
                    opts => opts.MapFrom(src => src.Password));

            CreateMap<UserRegisterDto, User>()
                .ForMember(
                    dest => dest.Username, 
                    opts => opts.MapFrom(src => src.Username))
                .ForMember(
                    dest => dest.Email, 
                    opts => opts.MapFrom(src => src.Email))
                .ForMember(
                    dest => dest.Password, 
                    opts => opts.MapFrom(src => src.Password));

            // Wallet Mapping
            CreateMap<WalletCreateUpdateDto, Wallet>();
            CreateMap<Wallet, WalletViewModel>().ReverseMap();
        }
		private DateTime ParseExpirationDate(string expireDateFormatted)
		{
            var date = new DateTime();
            if (expireDateFormatted == null)
            {
				date = DateTime.MinValue;
                return date;
			}
			int year = int.Parse(expireDateFormatted.Substring(2));
			int month = int.Parse(expireDateFormatted.Substring(0, 2));
			return new DateTime(2000 + year, month, 1).AddMonths(1).AddDays(-1).Date.AddHours(23).AddMinutes(59).AddSeconds(59);
		}
	}
}
