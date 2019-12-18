using Afonsoft.Amadeus;
using AmadeusShowcase.DAL.Entities;
using System.Collections.Generic;

namespace AmadeusShowcase.DAL.Repositories
{
    public interface IFlightRepository
    {
        Search FindExistingSearch(Search search);
        List<Flight> RetrieveFlightsFromDb(Search search);
        Response GetFlightsFromAmadeus(Search search);
        void AddFlight(Flight flight);
    }
}
