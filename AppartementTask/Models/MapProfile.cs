using AppartementTask.DAO;
using AutoMapper;

namespace AppartementTask.Models
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<LoginDto, Person>();
            CreateMap<RegisterDto, Person>();

            CreateMap<ResidenceDto, Residence>();
            CreateMap<Residence, ResidenceDto>();
        }
    }
}
