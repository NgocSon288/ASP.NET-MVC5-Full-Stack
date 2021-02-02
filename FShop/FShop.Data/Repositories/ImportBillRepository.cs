using FShop.Data.Infrastructure;
using FShop.Model.Models;

namespace FShop.Data.Repositories
{
    public interface IImportBillRepository : IRepository<ImportBill>
    {
    }

    public class ImportBillRepository : RepositoryBase<ImportBill>, IImportBillRepository
    {
        public ImportBillRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}
