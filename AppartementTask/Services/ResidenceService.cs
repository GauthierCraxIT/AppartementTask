using AppartementTask.CRUD;
using AppartementTask.DAO;
using AppartementTask.Models;
using AutoMapper;

namespace AppartementTask.Services
{
    public class ResidenceService
    {

        public Dao residenceDao { get; set; }
        public Dao pictureDao { get; set; }
        public IMapper mapper { get; set; }

        public ResidenceService(Dao residenceDao, Dao pictureDao, IMapper mapper)
        {
            this.residenceDao = residenceDao;
            this.pictureDao = pictureDao;
            this.mapper = mapper;
        }

        public void CreateResidence(ResidenceDto dto)
        {
            var residence = this.mapper.Map<Residence>(dto);
            this.residenceDao.Create<Residence>(residence);

            dto.Pictures.ForEach(x =>
            {
                var path = "C:/Users/Peppah/source/repos/AppartementTask/AppartementTask/wwwroot/images/";

                if (!Directory.Exists(Path.Combine(path, residence.Name)))
                    Directory.CreateDirectory(Path.Combine(path,residence.Name));

                byte[] imageBytes = Convert.FromBase64String(x.BasePath
                    .Replace("data:image/png;base64,", "")
                    .Replace("data:image/jpeg;base64,", "")
                    .Replace("data:image/jpg;base64,", ""));

                File.WriteAllBytes(Path.Combine(path, residence.Name, x.FileName), imageBytes);
            });
        }

        public List<ResidenceDto> GetResidences()
        {
            List<ResidenceDto> residenceDtos = new List<ResidenceDto>();
            var residences = this.residenceDao.Read<Residence>();

            residences.ForEach(x =>
            {
                var pics = this.pictureDao.Read<Picture>(f => f.Residence.Id == x.Id);
                x.Pictures = pics;

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

        public ResidenceDto FindResidenceByName(string name)
        {
            var residence = this.residenceDao.FindByCondition<Residence>(x => x.Name.Equals(name));

            var pics = this.pictureDao.Read<Picture>(f => f.Residence.Id == residence.Id);
            residence.Pictures = pics;

            return mapper.Map<ResidenceDto>(residence);
        }
    }
}
