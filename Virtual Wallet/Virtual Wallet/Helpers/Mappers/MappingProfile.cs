namespace Virtual_Wallet.Helpers.Mappers
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
