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
    public interface IProductService
    {
        Product Insert(Product entity);

        void Update(Product entity);

        void Delete(Product entity);

        void Delete(int id);

        IEnumerable<Product> GetAll();

        IEnumerable<Product> GetAllPaging(int page, int pageSize, out int totalRow);

        Product GetByID(int id);

        void SaveChanges();

    }
    public class ProductService : IProductService
    {
        private readonly IProductRepository _ProductRepository;
        private readonly IUnitOfWork _unitOfWork;


        public ProductService(IProductRepository ProductRepository, IUnitOfWork unitOfWork)
        {
            this._ProductRepository = ProductRepository;
            this._unitOfWork = unitOfWork;
        }

        public void Delete(Product entity)
        {
            _ProductRepository.Delete(entity);
        }

        public void Delete(int id)
        {
            _ProductRepository.Delete(id);
        }

        public IEnumerable<Product> GetAll()
        {
            return _ProductRepository.GetAll();
        }

        public IEnumerable<Product> GetAllPaging(int page, int pageSize, out int totalRow)
        {
            return _ProductRepository.GetMultiPaging(ms => true, out totalRow, page, pageSize);
        }

        public Product GetByID(int id)
        {
            return _ProductRepository.GetSingleById(id);
        }

        public Product Insert(Product entity)
        {
            return _ProductRepository.Add(entity);
        }

        public void SaveChanges()
        {
            _unitOfWork.Commit();
        }

        public void Update(Product entity)
        {
            _ProductRepository.Update(entity);
        }
    }
}
