using FShop.Data.Infrastructure;
using FShop.Model.Models;

namespace FShop.Data.Repositories
{
    public interface IMemberStatusRepository : IRepository<MemberStatus>
    {
    }

    public class MemberStatusRepository : RepositoryBase<MemberStatus>, IMemberStatusRepository
    {
        public MemberStatusRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}
