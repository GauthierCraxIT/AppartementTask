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
                //save the pics TEMP HARDCODE


                var path = "C:/Users/gauth/source/repos/AppartementTask/AppartementTask/wwwroot/images/";

                if (!Directory.Exists(Path.Combine(path, residence.Name)))
                    Directory.CreateDirectory(Path.Combine(path,residence.Name));

                byte[] imageBytes = Convert.FromBase64String(x.BasePath.Replace("data:image/png;base64,", ""));
                File.WriteAllBytes(Path.Combine(path, residence.Name, x.FileName), imageBytes);



                var pic = this.mapper.Map<Picture>(x);
                pic.Residence = residence;

                this.pictureDao.Create<Picture>(pic);
            });
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
