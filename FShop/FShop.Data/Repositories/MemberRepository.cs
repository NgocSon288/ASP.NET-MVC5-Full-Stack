using FShop.Data.Infrastructure;
using FShop.Model.Models;

namespace FShop.Data.Repositories
{
    public interface IMemberRepository : IRepository<Member>
    {
    }

    public class MemberRepository : RepositoryBase<Member>, IMemberRepository
    {
        public MemberRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}
