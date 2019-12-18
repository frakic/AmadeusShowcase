using AmadeusShowcase.DAL.Entities;
using System.Collections.Generic;
using System.Linq;

namespace AmadeusShowcase.DAL.Repositories
{
    public class AirportRepository : IAirportRepository
    {
        private readonly AmadeusDbContext db = new AmadeusDbContext();

        public List<Airport> GetAirports()
        {
            return db.Airports.ToList();
        }

        public Airport GetAirportById(int id)
        {
            return db.Airports.Find(id);
        }

        public Airport GetAirportByIata(string iata)
        {
            return db.Airports.Where(x => x.Iata == iata).FirstOrDefault();
        }
    }
}
