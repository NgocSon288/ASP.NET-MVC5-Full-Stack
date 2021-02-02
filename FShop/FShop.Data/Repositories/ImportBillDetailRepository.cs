using FShop.Data.Infrastructure;
using FShop.Model.Models;

namespace FShop.Data.Repositories
{
    public interface IImportBillDetailRepository : IRepository<ImportBillDetail>
    {
    }

    public class ImportBillDetailRepository : RepositoryBase<ImportBillDetail>, IImportBillDetailRepository
    {
        public ImportBillDetailRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}
