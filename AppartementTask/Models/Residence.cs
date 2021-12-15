using System.ComponentModel.DataAnnotations;

namespace AppartementTask.Models
{
    public class Residence
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        [Required]
        public int Bathrooms { get; set; }
        [Required]
        public int Toilets { get; set; }
        [Required]
        public int Bedrooms { get; set; }
        [Required]
        public bool SwimmingPool { get; set; }
        [Required]
        public bool Wifi { get; set; }
        [Required]
        public bool Breakfast { get; set; }
        [Required]
        public bool Kitchen { get; set; }
        [Required]
        public bool Television { get; set; }
        [Required]
        public bool NearbyBeach { get; set; }
        [Required]
        public bool NearbyCity { get; set; }
        [Required]
        public bool NearbySubway { get; set; }
        [Required]
        public bool NearbyTrainStation { get; set; }
        public ResidenceType ResidenceType { get; set; }
        [Required]
        public string Summary { get; set; }
        public virtual ICollection<Picture> Pictures { get; set; }
    }
}
