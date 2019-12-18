using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AmadeusShowcase.DAL.Entities
{
    public class Search
    {
        [Key]
        public int Id { get; set; }

        [Required(AllowEmptyStrings = false)]
        public int AirportFromId { get; set; }

        public virtual Airport AirportFrom { get; set; }

        [Required(AllowEmptyStrings = false)]
        public int AirportToId { get; set; }

        public virtual Airport AirportTo { get; set; }

        [Required]
        [Column(TypeName = "date")]
        public DateTime DepartureDate { get; set; }

        [Required]
        [Column(TypeName = "date")]
        public DateTime ReturnDate { get; set; }

        [Required]
        public int NumOfPassengers { get; set; }

        [Required]
        public int CurrencyId { get; set; }

        public virtual Currency Currency { get; set; }

        public virtual ICollection<Flight> Flights { get; set; }
    }
}