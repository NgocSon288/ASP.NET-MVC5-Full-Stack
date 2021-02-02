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
        private readonly IUnitOfWork _unitOfWork;


        public ImportBillService(IImportBillRepository ImportBillRepository, IUnitOfWork unitOfWork)
        {
            this._ImportBillRepository = ImportBillRepository;
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

        public ImportBill GetByID(int id)
        {
            return _ImportBillRepository.GetSingleById(id);
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
