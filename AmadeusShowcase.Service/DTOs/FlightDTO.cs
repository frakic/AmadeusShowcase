using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AmadeusShowcase.Service.DTOs
{
    public class FlightDTO
    {
        public int Id { get; set; }

        public int AirportFromId { get; set; }

        [Display(Name = "Polazište")]
        public virtual AirportDTO AirportFrom { get; set; }

        public int AirportToId { get; set; }

        [Display(Name = "Odredište")]
        public virtual AirportDTO AirportTo { get; set; }

        [Display(Name = "Polazak")]
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy.}")]
        public DateTime DepartureDate { get; set; }

        [Display(Name = "Povratak")]
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy.}")]
        public DateTime ReturnDate { get; set; }

        [Display(Name = "Presjedanja u polasku")]
        public int NumOfConnFlightsDeparture { get; set; }

        [Display(Name = "Presjedanja u povratku")]
        public int NumOfConnFlightsReturn { get; set; }

        [Display(Name = "Broj putnika")]
        public int NumOfPassengers { get; set; }

        public int CurrencyId { get; set; }

        [Display(Name = "Valuta")]
        public virtual CurrencyDTO Currency { get; set; }

        [Display(Name = "Cijena")]
        public double Price { get; set; }

        public virtual ICollection<SearchDTO> Search { get; set; }
    }
}