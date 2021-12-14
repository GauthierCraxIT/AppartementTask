namespace AppartementTask.DAO
{
    public class ResidenceDto
    {
        public ResidenceDto(int id, int floors, int bathrooms, int bedrooms, int toilets, ResidenceType residenceType)
        {
            Id = id;
            Floors = floors;
            Bathrooms = bathrooms;
            Bedrooms = bedrooms;
            Toilets = toilets;
            ResidenceType = residenceType;
        }

        public int Id { get; set; }

        public int Floors { get; set; }
        public int Bathrooms { get; set; }
        public int Bedrooms { get; set; }
        public int Toilets { get; set; }
        public string Summary { get; set; }
        public ResidenceType ResidenceType { get; set; }



    }
}
