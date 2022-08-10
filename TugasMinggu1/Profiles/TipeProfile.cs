using TugasMinggu1.Domain;
using TugasMinggu1.DTO;
using AutoMapper;

namespace TugasMinggu1.Profiles
{
    public class TipeProfile:Profile
    {
        public TipeProfile()
        {
            CreateMap<Tipe, TipeDTO>();
            CreateMap<TipeDTO, Tipe>();
           CreateMap<Tipe, Tipe_DTO>();
           CreateMap<Tipe_DTO, Tipe>();
            
            CreateMap<Tipe, TipeReadDTO>();
            CreateMap<TipeReadDTO, Tipe>();
            CreateMap<SwordWithTipeDTO, Tipe>();
            CreateMap<Tipe, SwordWithTipeDTO>();

            CreateMap<SwordWithAll, Tipe>();
           CreateMap<Tipe, SwordWithAll>();
            CreateMap<SamuraiWithAllDTO, Tipe>();
            CreateMap<Tipe, SamuraiWithAllDTO>();
            
            //CreateMap<Tipe, Sword>();
            //CreateMap<Sword,Tipe>();

        }
           
    }
}
