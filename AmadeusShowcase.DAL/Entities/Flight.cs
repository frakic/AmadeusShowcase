using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AmadeusShowcase.DAL.Entities
{
    public class Flight
    {
        public Flight()
        {
            this.Search = new HashSet<Search>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        public int AirportFromId { get; set; }

        public virtual Airport AirportFrom { get; set; }

        [Required]
        public int AirportToId { get; set; }

        public virtual Airport AirportTo { get; set; }

        [Required]
        [Column(TypeName = "date")]
        public DateTime DepartureDate { get; set; }

        [Column(TypeName = "date")]
        public DateTime ReturnDate { get; set; }

        public int NumOfConnFlightsDeparture { get; set; }

        public int NumOfConnFlightsReturn { get; set; }

        public int NumOfPassengers { get; set; }

        public int CurrencyId { get; set; }

        public virtual Currency Currency { get; set; }

        public double Price { get; set; }

        public virtual ICollection<Search> Search { get; set; }
    }
}