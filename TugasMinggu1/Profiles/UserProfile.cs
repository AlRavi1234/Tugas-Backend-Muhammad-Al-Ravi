
using AutoMapper;
using TugasMinggu1.Domain;
using TugasMinggu1.DTO;

namespace TugasMinggu1.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User, UserDTO>();
            CreateMap<UserDTO, User>();
            CreateMap<User, UserReadDTO>();
            CreateMap<UserReadDTO, User>();


        }

    }
}

