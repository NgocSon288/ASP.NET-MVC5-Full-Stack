using FShop.Data.Infrastructure;
using FShop.Model.Models;

namespace FShop.Data.Repositories
{
    public interface IPaymentMethodRepository : IRepository<PaymentMethod>
    {
    }

    public class PaymentMethodRepository : RepositoryBase<PaymentMethod>, IPaymentMethodRepository
    {
        public PaymentMethodRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}
