using System.ComponentModel.DataAnnotations;

namespace AmadeusShowcase.DAL.Entities
{
    public class Currency
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(3)]
        public string Code { get; set; }
    }
}