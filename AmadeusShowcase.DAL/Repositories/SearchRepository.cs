using AmadeusShowcase.DAL.Entities;

namespace AmadeusShowcase.DAL.Repositories
{
    public class SearchRepository : ISearchRepository
    {
        private readonly AmadeusDbContext db = new AmadeusDbContext();

        public void AddSearch(Search search)
        {
            db.Searches.Add(search);
            db.SaveChanges();
        }
    }
}
