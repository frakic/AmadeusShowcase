using AmadeusShowcase.DAL.Entities;
using System.Collections.Generic;

namespace AmadeusShowcase.DAL.Repositories
{
    public interface ICurrencyRepository
    {
        List<Currency> GetCurrencies();
        Currency GetCurrencyById(int id);
        Currency GetCurrencyByCode(string code);
    }
}
