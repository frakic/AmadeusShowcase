using AmadeusShowcase.DAL.Entities;
using AmadeusShowcase.DAL.Repositories;
using AmadeusShowcase.Service.DTOs;
using AutoMapper;
using System.Collections.Generic;

namespace AmadeusShowcase.Service.Services
{
    public class CurrencyService : ICurrencyService
    {
        private readonly IMapper mapper;
        private readonly ICurrencyRepository cr;

        public CurrencyService(IMapper mapper, ICurrencyRepository cr)
        {
            this.mapper = mapper;
            this.cr = cr;
        }

        public List<CurrencyDTO> MapCurrenciesToDTO()
        {
            List<Currency> currencies = GetCurrencies();

            List<CurrencyDTO> currenciessDTO = mapper.Map<List<CurrencyDTO>>(currencies);

            return currenciessDTO;
        }

        public CurrencyDTO GetCurrencyById(int id)
        {
            Currency currency = cr.GetCurrencyById(id);

            return mapper.Map<CurrencyDTO>(currency);
        }

        private List<Currency> GetCurrencies()
        {
            return cr.GetCurrencies();
        }
    }
}
