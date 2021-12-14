using System.ComponentModel.DataAnnotations;

namespace AppartementTask.Models
{
    public class Residence
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int Floors { get; set; }
        [Required]
        public int Bathrooms { get; set; }
        [Required]
        public int Bedrooms { get; set; }
        [Required]
        public int Toilets { get; set; }
        [Required]
        public ResidenceType ResidenceType { get; set; }
        [Required]
        public string Summary { get; set; }
        public virtual ICollection<Picture> Pictures { get; set; }
    }
}
