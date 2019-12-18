using AmadeusShowcase.DAL.Entities;
using AmadeusShowcase.Service.DTOs;
using AutoMapper;

namespace AmadeusShowcase.Service
{
    public class AutoMapperBootstrap : Profile
    {
        public AutoMapperBootstrap()
        {
            CreateMap<Airport, AirportDTO>();
            CreateMap<AirportDTO, Airport>();

            CreateMap<Currency, CurrencyDTO>();
            CreateMap<CurrencyDTO, Currency>();

            CreateMap<Flight, FlightDTO>();
            CreateMap<FlightDTO, Flight>();

            CreateMap<SearchDTO, Search>();
            CreateMap<Search, SearchDTO>();
        }
    }
}
