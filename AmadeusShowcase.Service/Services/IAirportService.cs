using AmadeusShowcase.Service.DTOs;
using System.Collections.Generic;

namespace AmadeusShowcase.Service.Services
{
    public interface IAirportService
    {
        List<AirportDTO> MapAirportsToDTO();
        AirportDTO GetAirportById(int id);
    }
}
