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

        public virtual Person Person { get; set; }
    }
}
