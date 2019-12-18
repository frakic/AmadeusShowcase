using AmadeusShowcase.Service.DTOs;
using System.Collections.Generic;

namespace AmadeusShowcase.Service.Services
{
    public interface IFlightService
    {
        List<FlightDTO> FindFlights(SearchDTO searchDTO);
    }
}
