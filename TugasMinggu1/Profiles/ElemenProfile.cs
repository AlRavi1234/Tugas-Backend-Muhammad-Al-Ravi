using TugasMinggu1.Domain;
using TugasMinggu1.DTO;
using AutoMapper;


namespace TugasMinggu1.Profiles
{
    public class ElemenProfile:Profile
    {
        public ElemenProfile()
        {
            CreateMap<Elemen, ElemenDTO>();
            CreateMap<ElemenDTO, Elemen>();

            CreateMap<Elemen, ElemenIdDTO>();
            CreateMap<ElemenIdDTO, Elemen>();

            CreateMap<Elemen, ElemenIdNameDTO>();
            CreateMap<ElemenIdNameDTO, Elemen>();
            

             //   CreateMap<Elemen, SamuraiWithAllDTO>();
          //  CreateMap<SamuraiWithAllDTO, Elemen>();

            CreateMap<Elemen, ElemenWithSwordDTO>();
            CreateMap<ElemenWithSwordDTO, Elemen>();

          //  CreateMap<Elemen, SwordIdDTO>();
           // CreateMap<SwordIdDTO, Elemen>();


        }
       
    }
}
