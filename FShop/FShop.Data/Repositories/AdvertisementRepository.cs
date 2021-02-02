using FShop.Data.Infrastructure;
using FShop.Model.Models;

namespace FShop.Data.Repositories
{
    public interface IAdvertisementRepository : IRepository<Advertisement>
    {
    }

    public class AdvertisementRepository : RepositoryBase<Advertisement>, IAdvertisementRepository
    {
        public AdvertisementRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}