
using TugasMinggu1.Domain;
using TugasMinggu1.DTO;
using AutoMapper;

namespace TugasMinggu1.Profiles
{
    public class SwordProfile:Profile
    {
        public SwordProfile()
        {
            CreateMap<Sword, SwordCreateDTO>();
            CreateMap<SwordCreateDTO, Sword>();
            CreateMap<Sword, SwordDTO>();
            CreateMap<SwordDTO, Sword>();

            CreateMap<Sword, SwordReadDTO>();
            CreateMap<SwordReadDTO, Sword>();

            CreateMap<Sword, SwordWithTipeDTO>();
            CreateMap<SwordWithTipeDTO, Sword>();

            
            CreateMap<Sword, SwordWithTipeReadDTO>();
            CreateMap<SwordWithTipeReadDTO, Sword>();

            CreateMap<Sword, SwordWithTipeElemenDTO>();
            CreateMap<SwordWithTipeElemenDTO, Sword>();

            CreateMap<Sword, SwordWithAll>();
            CreateMap<SwordWithAll, Sword>();

            CreateMap<Sword, SwordWithElemenDTO>();
            CreateMap<SwordWithElemenDTO, Sword>();

            CreateMap<Sword, SwordIdDTO>();
            CreateMap<SwordIdDTO, Sword>();
        }


    }
}
