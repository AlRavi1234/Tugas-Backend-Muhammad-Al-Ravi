using AutoMapper;
using TugasMinggu1.Domain;
using TugasMinggu1.DTO;

namespace TugasMinggu1.Profiles
{
    public class SamuraiProfile : Profile
    {
        public SamuraiProfile()
        {
            CreateMap<Samurai, SamuraiReadDTO>();
           // CreateMap<SamuraiWithQuotesDTO, Samurai>();
            //CreateMap<Samurai, SamuraiWithQuotesDTO>();
            CreateMap<SamuraiReadDTO, Samurai>();
            CreateMap<SamuraiCreateDTO, Samurai>();
             CreateMap<Samurai, SamuraiCreateDTO>();
            CreateMap<SamuraiWithSwordDTO, Samurai>();
            CreateMap<Samurai, SamuraiWithSwordDTO>();

            CreateMap<SamuraiWithAllDTO, Samurai>();
            CreateMap<Samurai, SamuraiWithAllDTO>();


            // CreateMap<QuoteDTO, Samurai>();
            // CreateMap<Quote, QuoteDTO>();

        }
    }
}
