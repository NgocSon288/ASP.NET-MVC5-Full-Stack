using FShop.Data.Infrastructure;
using FShop.Model.Models;

namespace FShop.Data.Repositories
{
    public interface IOrderStatusRepository : IRepository<OrderStatus>
    {
    }

    public class OrderStatusRepository : RepositoryBase<OrderStatus>, IOrderStatusRepository
    {
        public OrderStatusRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}
