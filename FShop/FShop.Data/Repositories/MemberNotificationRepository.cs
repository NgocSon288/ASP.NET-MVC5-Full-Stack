using FShop.Data.Infrastructure;
using FShop.Model.Models;

namespace FShop.Data.Repositories
{
    public interface IMemberNotificationRepository : IRepository<MemberNotification>
    {
    }

    public class MemberNotificationRepository : RepositoryBase<MemberNotification>, IMemberNotificationRepository
    {
        public MemberNotificationRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}
