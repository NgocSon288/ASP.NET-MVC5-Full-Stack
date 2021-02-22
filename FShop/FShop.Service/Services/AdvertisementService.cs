using FShop.Data.Infrastructure;
using FShop.Data.Repositories;
using FShop.Model.Models;
using System.Collections.Generic;

namespace FShop.Service.Services
{
    public interface IAdvertisementService
    {
        Advertisement GetByDisplayOrder(int displayOrder);

        Advertisement Insert(Advertisement entity);

        void Update(Advertisement entity);

        void Delete(Advertisement entity);

        void Delete(int id);

        IEnumerable<Advertisement> GetAll();

        IEnumerable<Advertisement> GetAllPaging(int page, int pageSize, out int totalRow);

        Advertisement GetByID(int id);

        void SaveChanges();
    }

    public class AdvertisementService : IAdvertisementService
    {
        private readonly IAdvertisementRepository _advertisementRepository;
        private readonly IUnitOfWork _unitOfWork;

        public AdvertisementService(IAdvertisementRepository advertisementRepository, IUnitOfWork unitOfWork)
        {
            this._advertisementRepository = advertisementRepository;
            this._unitOfWork = unitOfWork;
        }

        public void Delete(Advertisement entity)
        {
            _advertisementRepository.Delete(entity);
        }

        public void Delete(int id)
        {
            _advertisementRepository.Delete(id);
        }

        public IEnumerable<Advertisement> GetAll()
        {
            return _advertisementRepository.GetAll();
        }

        public IEnumerable<Advertisement> GetAllPaging(int page, int pageSize, out int totalRow)
        {
            return _advertisementRepository.GetMultiPaging(ad => ad.Status.Value, out totalRow, page, pageSize);
        }

        public Advertisement GetByDisplayOrder(int displayOrder)
        {
            return _advertisementRepository.GetSingleByCondition(ad => ad.DisplayOrder == displayOrder);
        }

        public Advertisement GetByID(int id)
        {
            return _advertisementRepository.GetSingleById(id);
        }

        public Advertisement Insert(Advertisement entity)
        {
            return _advertisementRepository.Add(entity);
        }

        public void SaveChanges()
        {
            _unitOfWork.Commit();
        }

        public void Update(Advertisement entity)
        {
            _advertisementRepository.Update(entity);
        }
    }
}