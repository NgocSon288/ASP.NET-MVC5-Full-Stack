using FShop.Data.Infrastructure;
using FShop.Data.Repositories;
using FShop.Model.Models;
using System.Collections.Generic;

namespace FShop.Service.Services
{
    public interface ISupplierService
    {
        Supplier Insert(Supplier entity);

        void Update(Supplier entity);

        void Delete(Supplier entity);

        void Delete(int id);

        IEnumerable<Supplier> GetAll();

        IEnumerable<Supplier> GetAllPaging(int page, int pageSize, out int totalRow);

        Supplier GetByID(int id);

        void SaveChanges();
    }

    public class SupplierService : ISupplierService
    {
        private readonly ISupplierRepository _SupplierRepository;
        private readonly IUnitOfWork _unitOfWork;

        public SupplierService(ISupplierRepository SupplierRepository, IUnitOfWork unitOfWork)
        {
            this._SupplierRepository = SupplierRepository;
            this._unitOfWork = unitOfWork;
        }

        public void Delete(Supplier entity)
        {
            _SupplierRepository.Delete(entity);
        }

        public void Delete(int id)
        {
            _SupplierRepository.Delete(id);
        }

        public IEnumerable<Supplier> GetAll()
        {
            return _SupplierRepository.GetAll();
        }

        public IEnumerable<Supplier> GetAllPaging(int page, int pageSize, out int totalRow)
        {
            return _SupplierRepository.GetMultiPaging(ms => true, out totalRow, page, pageSize);
        }

        public Supplier GetByID(int id)
        {
            return _SupplierRepository.GetSingleById(id);
        }

        public Supplier Insert(Supplier entity)
        {
            return _SupplierRepository.Add(entity);
        }

        public void SaveChanges()
        {
            _unitOfWork.Commit();
        }

        public void Update(Supplier entity)
        {
            _SupplierRepository.Update(entity);
        }
    }
}