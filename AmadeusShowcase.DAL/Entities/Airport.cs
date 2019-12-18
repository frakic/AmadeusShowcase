using System.ComponentModel.DataAnnotations;

namespace AmadeusShowcase.DAL.Entities
{
    public class Airport
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(3)]
        public string Iata { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [StringLength(100)]
        public string Location { get; set; }

        [Required]
        [StringLength(50)]
        public string Country { get; set; }
    }
}