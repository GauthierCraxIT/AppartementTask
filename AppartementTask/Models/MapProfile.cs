using AppartementTask.DAO;
using AppartementTask.DTO;
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

            CreateMap<PictureDto, Picture>();
            CreateMap<Picture, PictureDto>();


        }
    }
}
