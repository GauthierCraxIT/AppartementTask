using AppartementTask.CRUD;
using AppartementTask.DAO;
using AppartementTask.Models;
using AutoMapper;

namespace AppartementTask.Services
{
    public class ResidenceService
    {

        public Dao residenceDao { get; set; }
        public IMapper mapper { get; set; }

        public ResidenceService(Dao residenceDao, IMapper mapper)
        {
            this.residenceDao = residenceDao;
            this.mapper = mapper;
        }

        public void CreateResidence(ResidenceDto dto)
        {
            var residence = this.mapper.Map<Residence>(dto);
            this.residenceDao.Create<Residence>(residence);
            
        }

        public List<ResidenceDto> GetResidences()
        {
            List<ResidenceDto> residenceDtos = new List<ResidenceDto>();
            this.residenceDao.Read<Residence>().ForEach(x =>
            {
                var residenceDto = mapper.Map<ResidenceDto>(x);
                residenceDtos.Add(residenceDto);
            });

            return residenceDtos;
        }

        public void UpdateResidence(ResidenceDto dto)
        {
            var residence = this.mapper.Map<Residence>(dto);
            this.residenceDao.Update<Residence>(residence);
        }

        public void DeleteResidence(ResidenceDto dto)
        {
            var residence = this.mapper.Map<Residence>(dto);
            this.residenceDao.Delete<Residence>(residence);
        }

        private ResidenceDto FindResidenceById(int id)
        {
            var residence = this.residenceDao.FindById<Residence>(id);
            return mapper.Map<ResidenceDto>(residence);
        }
    }
}
