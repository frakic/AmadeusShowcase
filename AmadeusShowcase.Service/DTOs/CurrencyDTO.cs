using System.ComponentModel.DataAnnotations;

namespace AmadeusShowcase.Service.DTOs
{
    public class CurrencyDTO
    {
        public int Id { get; set; }

        [Display(Name = "Valuta")]
        public string Code { get; set; }
    }
}