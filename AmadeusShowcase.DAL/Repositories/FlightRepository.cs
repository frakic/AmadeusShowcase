using Afonsoft.Amadeus;
using AmadeusShowcase.DAL.Entities;
using AmadeusShowcase.DAL.Properties;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AmadeusShowcase.DAL.Repositories
{
    public class FlightRepository : IFlightRepository
    {
        private readonly AmadeusDbContext db = new AmadeusDbContext();

        public Search FindExistingSearch(Search search)
        {
            Search existingSearch = db.Searches.Where(x => x.AirportFromId == search.AirportFromId &&
                                                      x.AirportToId == search.AirportToId &&
                                                      x.DepartureDate == search.DepartureDate &&
                                                      x.ReturnDate == search.ReturnDate &&
                                                      x.NumOfPassengers == search.NumOfPassengers &&
                                                      x.CurrencyId == search.CurrencyId).FirstOrDefault();

            return existingSearch;
        }

        public List<Flight> RetrieveFlightsFromDb(Search search)
        {
            return db.Flights.Where(f => f.Search.Any(s => s.Id == search.Id)).ToList();
        }

        public Response GetFlightsFromAmadeus(Search search)
        {
                Amadeus amadeus = Amadeus.Builder(Settings.Default.clientId, Settings.Default.clientSecret).Build();

                Response response = amadeus.Get("/v1/shopping/flight-offers", Params
                    .With("origin", search.AirportFrom.Iata)
                    .And("destination", search.AirportTo.Iata)
                    .And("departureDate", search.DepartureDate.ToString("yyyy-MM-dd"))
                    .And("returnDate", search.ReturnDate.ToString("yyyy-MM-dd"))
                    .And("currency", search.Currency.Code)
                    .And("adults", search.NumOfPassengers));

                return response;
            
        }

        public void AddFlight(Flight flight)
        {
            db.Flights.Add(flight);
            db.SaveChanges();
        }
    }
}
