using FShop.Data.Infrastructure;
using FShop.Model.Models;

namespace FShop.Data.Repositories
{
    public interface IPermissionCategoryMemberRepository : IRepository<PermissionCategoryMember>
    {
    }

    public class PermissionCategoryMemberRepository : RepositoryBase<PermissionCategoryMember>, IPermissionCategoryMemberRepository
    {
        public PermissionCategoryMemberRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}