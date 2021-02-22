using FShop.Data.Infrastructure;
using FShop.Model.Models;

namespace FShop.Data.Repositories
{
    public interface IPermissionRepository : IRepository<Permission>
    {
    }

    public class PermissionRepository : RepositoryBase<Permission>, IPermissionRepository
    {
        public PermissionRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}