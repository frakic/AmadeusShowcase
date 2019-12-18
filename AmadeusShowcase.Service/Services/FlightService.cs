using Afonsoft.Amadeus;
using AmadeusShowcase.DAL.Entities;
using AmadeusShowcase.DAL.Repositories;
using AmadeusShowcase.Service.DTOs;
using AutoMapper;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Linq;

namespace AmadeusShowcase.Service.Services
{
    public class FlightService : IFlightService
    {
        private readonly IMapper mapper;
        private readonly IFlightRepository fr;
        private readonly IAirportRepository ar;
        private readonly ICurrencyRepository cr;
        private readonly ISearchRepository sr;

        public FlightService(IMapper mapper, IFlightRepository fr, IAirportRepository ar, ICurrencyRepository cr, ISearchRepository sr)
        {
            this.mapper = mapper;
            this.fr = fr;
            this.ar = ar;
            this.cr = cr;
            this.sr = sr;
        }

        public List<FlightDTO> FindFlights(SearchDTO searchDTO)
        {
            Search search = mapper.Map<Search>(searchDTO);

            Search existingSearch = fr.FindExistingSearch(search);

            if (existingSearch != null)
            {
                List<Flight> flights = fr.RetrieveFlightsFromDb(existingSearch);
                return mapper.Map<List<FlightDTO>>(flights);
            }

            else
            {
                Response response = fr.GetFlightsFromAmadeus(search);

                JObject flightJObject = JObject.Parse(response.Body);

                List<JToken> results = flightJObject["data"].Children().ToList();

                List<Flight> flights = new List<Flight>();

                foreach (JToken result in results)
                {
                    Flight flight = new Flight()
                    {
                        AirportFrom = ar.GetAirportByIata(search.AirportFrom.Iata),
                        AirportTo = ar.GetAirportByIata(search.AirportTo.Iata),
                        Currency = cr.GetCurrencyByCode(search.Currency.Code),
                        DepartureDate = search.DepartureDate,
                        ReturnDate = search.ReturnDate,
                        NumOfConnFlightsDeparture = result["offerItems"].First["services"].First["segments"].Count(),
                        NumOfConnFlightsReturn = result["offerItems"].First["services"].Last["segments"].Count(),
                        NumOfPassengers = search.NumOfPassengers,
                        Price = (double)result["offerItems"].First["price"]["total"]
                    };

                    flights.Add(flight);
                }

                foreach (Flight flight in flights)
                {
                    flight.Search.Add(search);
                    fr.AddFlight(flight);
                }
                sr.AddSearch(search);

                return mapper.Map<List<FlightDTO>>(flights);
            }
        }
    }
}
