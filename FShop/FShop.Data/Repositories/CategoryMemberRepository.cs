using FShop.Data.Infrastructure;
using FShop.Model.Models;

namespace FShop.Data.Repositories
{
    public interface ICategoryMemberRepository : IRepository<CategoryMember>
    {
    }

    public class CategoryMemberRepository : RepositoryBase<CategoryMember>, ICategoryMemberRepository
    {
        public CategoryMemberRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}