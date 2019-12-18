using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AmadeusShowcase.Service.DTOs
{
    public class SearchDTO
    {
        public int Id { get; set; }
        
        public int AirportFromId { get; set; }

        [Display(Name = "Polazište")]
        public virtual AirportDTO AirportFrom { get; set; }

        public int AirportToId { get; set; }

        [Display(Name = "Odredište")]
        public virtual AirportDTO AirportTo { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy}", ApplyFormatInEditMode = true)]
        [ValidationDate]
        [Display(Name = "Polazak")]
        public DateTime DepartureDate { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy}", ApplyFormatInEditMode = true)]
        [ValidationDate]
        [Display(Name = "Povratak")]
        public DateTime ReturnDate { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Unesite broj putnika")]
        [Display(Name = "Broj putnika")]
        public int NumOfPassengers { get; set; }

        public int CurrencyId { get; set; }

        [Display(Name = "Valuta")]
        public virtual CurrencyDTO Currency { get; set; }

        public virtual ICollection<FlightDTO> Flights { get; set; }
    }
}