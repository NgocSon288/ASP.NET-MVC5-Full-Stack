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
    public interface IBrandService
    {
        Brand Insert(Brand entity);

        void Update(Brand entity);

        void Delete(Brand entity);

        void Delete(int id);

        IEnumerable<Brand> GetAll();

        IEnumerable<Brand> GetAllPaging(int page, int pageSize, out int totalRow);

        Brand GetByID(int id);

        void SaveChanges();

    }
    public class BrandService : IBrandService
    {
        private readonly IBrandRepository _BrandRepository;
        private readonly IUnitOfWork _unitOfWork;


        public BrandService(IBrandRepository BrandRepository, IUnitOfWork unitOfWork)
        {
            this._BrandRepository = BrandRepository;
            this._unitOfWork = unitOfWork;
        }

        public void Delete(Brand entity)
        {
            _BrandRepository.Delete(entity);
        }

        public void Delete(int id)
        {
            _BrandRepository.Delete(id);
        }

        public IEnumerable<Brand> GetAll()
        {
            return _BrandRepository.GetAll();
        }

        public IEnumerable<Brand> GetAllPaging(int page, int pageSize, out int totalRow)
        {
            return _BrandRepository.GetMultiPaging(ms => true, out totalRow, page, pageSize);
        }

        public Brand GetByID(int id)
        {
            return _BrandRepository.GetSingleById(id);
        }

        public Brand Insert(Brand entity)
        {
            return _BrandRepository.Add(entity);
        }

        public void SaveChanges()
        {
            _unitOfWork.Commit();
        }

        public void Update(Brand entity)
        {
            _BrandRepository.Update(entity);
        }
    }
}
