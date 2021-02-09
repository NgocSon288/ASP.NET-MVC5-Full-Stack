using FShop.Data.Infrastructure;
using FShop.Model.Models;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace FShop.Data.Repositories
{
    public interface IMemberRepository : IRepository<Member>
    {
        Task<Member> GetByUserName(string userName);
    }

    public class MemberRepository : RepositoryBase<Member>, IMemberRepository
    {
        public MemberRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }

        public async Task<Member> GetByUserName(string userName)
        {
            return await DbContext.Members.FirstOrDefaultAsync(m => m.UserName == userName);
        }
    }
}
