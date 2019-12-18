using AmadeusShowcase.DAL.Entities;
using System.Collections.Generic;
using System.Linq;

namespace AmadeusShowcase.DAL.Repositories
{
    public class CurrencyRepository : ICurrencyRepository
    {
        private readonly AmadeusDbContext db = new AmadeusDbContext();

        public List<Currency> GetCurrencies()
        {
            return db.Currencies.ToList();
        }

        public Currency GetCurrencyById(int id)
        {
            return db.Currencies.Find(id);
        }

        public Currency GetCurrencyByCode(string code)
        {
            return db.Currencies.Where(x => x.Code == code).FirstOrDefault();
        }
    }
}
