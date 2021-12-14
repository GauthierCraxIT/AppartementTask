using System.ComponentModel.DataAnnotations;

namespace AppartementTask.Models
{
    public class Picture
    {
        [Key]
        public int Id { get; set; }
        public string FileName { get; set; }
        public virtual Residence Residence{ get; set; }
    }
}
