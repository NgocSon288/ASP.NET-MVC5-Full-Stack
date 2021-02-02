using FShop.Data.Infrastructure;
using FShop.Model.Models;

namespace FShop.Data.Repositories
{
    public interface ICategoryNotificationRepository : IRepository<CategoryNotification>
    {
    }

    public class CategoryNotificationRepository : RepositoryBase<CategoryNotification>, ICategoryNotificationRepository
    {
        public CategoryNotificationRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}
