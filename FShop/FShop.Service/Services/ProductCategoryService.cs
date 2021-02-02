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
    public interface IProductCategoryService
    {
        ProductCategory Insert(ProductCategory entity);

        void Update(ProductCategory entity);

        void Delete(ProductCategory entity);

        void Delete(int id);

        IEnumerable<ProductCategory> GetAll();

        IEnumerable<ProductCategory> GetAllPaging(int page, int pageSize, out int totalRow);

        ProductCategory GetByID(int id);

        void SaveChanges();

    }
    public class ProductCategoryService : IProductCategoryService
    {
        private readonly IProductCategoryRepository _ProductCategoryRepository;
        private readonly IUnitOfWork _unitOfWork;


        public ProductCategoryService(IProductCategoryRepository ProductCategoryRepository, IUnitOfWork unitOfWork)
        {
            this._ProductCategoryRepository = ProductCategoryRepository;
            this._unitOfWork = unitOfWork;
        }

        public void Delete(ProductCategory entity)
        {
            _ProductCategoryRepository.Delete(entity);
        }

        public void Delete(int id)
        {
            _ProductCategoryRepository.Delete(id);
        }

        public IEnumerable<ProductCategory> GetAll()
        {
            return _ProductCategoryRepository.GetAll();
        }

        public IEnumerable<ProductCategory> GetAllPaging(int page, int pageSize, out int totalRow)
        {
            return _ProductCategoryRepository.GetMultiPaging(ms => true, out totalRow, page, pageSize);
        }

        public ProductCategory GetByID(int id)
        {
            return _ProductCategoryRepository.GetSingleById(id);
        }

        public ProductCategory Insert(ProductCategory entity)
        {
            return _ProductCategoryRepository.Add(entity);
        }

        public void SaveChanges()
        {
            _unitOfWork.Commit();
        }

        public void Update(ProductCategory entity)
        {
            _ProductCategoryRepository.Update(entity);
        }
    }
}
