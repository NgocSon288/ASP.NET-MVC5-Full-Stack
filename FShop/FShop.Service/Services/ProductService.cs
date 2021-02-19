using FShop.Data.Infrastructure;
using FShop.Data.Repositories;
using FShop.Model.Models;
using System.Collections.Generic;
using System.Linq;

namespace FShop.Service.Services
{
    public interface IProductService
    {
        IEnumerable<Product> GetProductPage(string key, int page, int pageSize, out int pageMax, int installment, int brandID, int supplierID, int categoryID);

        bool IsAliasOk(string alias, int id = 0);

        bool IsDisplayNameOk(string name, int id = 0);

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

        public bool IsAliasOk(string alias, int id = 0)
        {
            if (alias == null)
                return false;

            var products = _ProductRepository.GetAll().ToList();
            var product = products.FirstOrDefault(p => p.Alias.ToLower() == alias.ToLower() && p.ID != id);

            return product == null || product.ID == id;
        }

        public bool IsDisplayNameOk(string name, int id = 0)
        {
            if (name == null)
                return false;

            var products = _ProductRepository.GetAll().ToList();
            var product = products.FirstOrDefault(p => p.Name.ToLower() == name.ToLower() && p.ID != id);

            return product == null || product.ID == id;
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

        public IEnumerable<Product> GetProductPage(string key, int page, int pageSize, out int pageMax, int installment, int brandID, int supplierID, int categoryID)
        {
            var products = _ProductRepository.GetAll();

            if(key != null && key != "")
            {
                products = products.Where(p => p.Name.ToLower().Contains(key.ToLower()) || p.Alias.ToLower().Contains(key.ToLower()));
            }

            if(installment == -1)
            {
                products = products.Where(p => !p.IsInstallment);
            }
            else if(installment == 1)
            {
                products = products.Where(p => p.IsInstallment);
            }

            if(brandID != 0)
            {
                products = products.Where(p => p.BrandID == brandID);
            }

            if (supplierID != 0)
            {
                products = products.Where(p => p.SupplierID == supplierID);
            }

            if (categoryID != 0)
            {
                products = products.Where(p => p.CategoryID == categoryID);
            }

            pageMax = products.Count();

            try
            {
                products = products.Skip((page - 1) * pageSize);

                return products.Take(pageSize);
            }
            catch (System.Exception)
            {
                return products;
            }
        } 
    }
}