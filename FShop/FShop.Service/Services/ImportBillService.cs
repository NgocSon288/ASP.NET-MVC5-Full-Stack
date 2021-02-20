using FShop.Data.Infrastructure;
using FShop.Data.Repositories;
using FShop.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FShop.Service.Services
{
    public interface IImportBillService
    {
        IEnumerable<ImportBill> GetImportBillPage(int page, int pageSize, out int pageMax, DateTime? startDate, DateTime? endDate);

        ImportBill Insert(ImportBill entity);

        void Update(ImportBill entity);

        void Delete(ImportBill entity);

        void Delete(int id);

        IEnumerable<ImportBill> GetAll();

        IEnumerable<ImportBill> GetAllPaging(int page, int pageSize, out int totalRow);

        ImportBill GetByID(int id);

        void SaveChanges();

    }
    public class ImportBillService : IImportBillService
    {
        private readonly IImportBillRepository _ImportBillRepository;
        private readonly IImportBillDetailRepository _importBillDetailRepository;
        private readonly IUnitOfWork _unitOfWork;


        public ImportBillService(IImportBillRepository ImportBillRepository, IImportBillDetailRepository importBillDetailRepository, IUnitOfWork unitOfWork)
        {
            this._ImportBillRepository = ImportBillRepository;
            this._importBillDetailRepository = importBillDetailRepository;
            this._unitOfWork = unitOfWork;
        }

        public void Delete(ImportBill entity)
        {
            _ImportBillRepository.Delete(entity);
        }

        public void Delete(int id)
        {
            _ImportBillRepository.Delete(id);
        }

        public IEnumerable<ImportBill> GetAll()
        {
            return _ImportBillRepository.GetAll();
        }

        public IEnumerable<ImportBill> GetAllPaging(int page, int pageSize, out int totalRow)
        {
            return _ImportBillRepository.GetMultiPaging(ms => true, out totalRow, page, pageSize);
        }

        //error
        public ImportBill GetByID(int id)
        {
            var import = _ImportBillRepository.GetSingleById(id);
            import.ImportBillDetails = _importBillDetailRepository.GetMulti(ibd => ibd.ImportBillID == id).ToList();

            return import;
        }


        public IEnumerable<ImportBill> GetImportBillPage(int page, int pageSize, out int pageMax, DateTime? startDate, DateTime? endDate)
        {
            var importBills = _ImportBillRepository.GetAll();

            if (startDate != null)
            {
                importBills = importBills.Where(ib => ib.CreatedDate >= startDate);
            }

            if (endDate != null)
            {
                importBills = importBills.Where(ib => ib.CreatedDate <= endDate);
            }

            pageMax = importBills.Count();

            try
            {
                importBills = importBills.Skip((page - 1) * pageSize);

                return importBills.Take(pageSize);
            }
            catch (System.Exception)
            {
                return importBills;
            }
        }

        public ImportBill Insert(ImportBill entity)
        {
            return _ImportBillRepository.Add(entity);
        }

        public void SaveChanges()
        {
            _unitOfWork.Commit();
        }

        public void Update(ImportBill entity)
        {
            _ImportBillRepository.Update(entity);
        }
    }
}
