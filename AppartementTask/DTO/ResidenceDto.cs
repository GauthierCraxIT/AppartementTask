using AppartementTask.DTO;

namespace AppartementTask.DAO
{
    public class ResidenceDto
    {
        public string Name { get; set; }
        public int Bathrooms { get; set; }
        public int Toilets { get; set; }
        public int Bedrooms { get; set; }
        public bool SwimmingPool { get; set; }
        public bool Wifi { get; set; }
        public bool Breakfast { get; set; }
        public bool Kitchen { get; set; }
        public bool Television { get; set; }
        public bool NearbyBeach { get; set; }
        public bool NearbyCity { get; set; }
        public bool NearbySubway { get; set; }
        public bool NearbyTrainStation { get; set; }
        public ResidenceType ResidenceType { get; set; }
        public string Summary { get; set; }
        public List<PictureDto> Pictures { get; set; }



    }
}
