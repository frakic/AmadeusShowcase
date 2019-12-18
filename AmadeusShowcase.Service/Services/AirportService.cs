using AmadeusShowcase.DAL.Entities;
using AmadeusShowcase.DAL.Repositories;
using AmadeusShowcase.Service.DTOs;
using AutoMapper;
using System.Collections.Generic;

namespace AmadeusShowcase.Service.Services
{
    public class AirportService : IAirportService
    {
        private readonly IMapper mapper;
        private readonly IAirportRepository ar;

        public AirportService(IMapper mapper, IAirportRepository ar)
        {
            this.mapper = mapper;
            this.ar = ar;
        }

        public List<AirportDTO> MapAirportsToDTO()
        {
            List<Airport> airports = GetAirports();

            List<AirportDTO> airportsDTO = mapper.Map<List<AirportDTO>>(airports);

            return airportsDTO;
        }

        public AirportDTO GetAirportById(int id)
        {
            Airport airport = ar.GetAirportById(id);

            return mapper.Map<AirportDTO>(airport);
        }

        private List<Airport> GetAirports()
        {
            return ar.GetAirports();
        }
    }
}
