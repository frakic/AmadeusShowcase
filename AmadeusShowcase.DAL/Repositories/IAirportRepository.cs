using AmadeusShowcase.DAL.Entities;
using System.Collections.Generic;

namespace AmadeusShowcase.DAL.Repositories
{
    public interface IAirportRepository
    {
        List<Airport> GetAirports();
        Airport GetAirportById(int id);
        Airport GetAirportByIata(string iata);
    }
}
