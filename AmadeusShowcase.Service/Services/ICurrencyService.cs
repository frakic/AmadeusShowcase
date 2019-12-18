using AmadeusShowcase.Service.DTOs;
using System.Collections.Generic;

namespace AmadeusShowcase.Service.Services
{
    public interface ICurrencyService
    {
        List<CurrencyDTO> MapCurrenciesToDTO();
        CurrencyDTO GetCurrencyById(int id);
    }
}
