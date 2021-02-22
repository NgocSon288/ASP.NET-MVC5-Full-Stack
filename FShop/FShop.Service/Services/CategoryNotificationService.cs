using FShop.Data.Infrastructure;
using FShop.Data.Repositories;
using FShop.Model.Models;
using System.Collections.Generic;

namespace FShop.Service.Services
{
    public interface ICategoryNotificationService
    {
        CategoryNotification Insert(CategoryNotification entity);

        void Update(CategoryNotification entity);

        void Delete(CategoryNotification entity);

        void Delete(int id);

        IEnumerable<CategoryNotification> GetAll();

        IEnumerable<CategoryNotification> GetAllPaging(int page, int pageSize, out int totalRow);

        CategoryNotification GetByID(int id);

        void SaveChanges();
    }

    public class CategoryNotificationService : ICategoryNotificationService
    {
        private readonly ICategoryNotificationRepository _CategoryNotificationRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CategoryNotificationService(ICategoryNotificationRepository CategoryNotificationRepository, IUnitOfWork unitOfWork)
        {
            this._CategoryNotificationRepository = CategoryNotificationRepository;
            this._unitOfWork = unitOfWork;
        }

        public void Delete(CategoryNotification entity)
        {
            _CategoryNotificationRepository.Delete(entity);
        }

        public void Delete(int id)
        {
            _CategoryNotificationRepository.Delete(id);
        }

        public IEnumerable<CategoryNotification> GetAll()
        {
            return _CategoryNotificationRepository.GetAll();
        }

        public IEnumerable<CategoryNotification> GetAllPaging(int page, int pageSize, out int totalRow)
        {
            return _CategoryNotificationRepository.GetMultiPaging(ms => true, out totalRow, page, pageSize);
        }

        public CategoryNotification GetByID(int id)
        {
            return _CategoryNotificationRepository.GetSingleById(id);
        }

        public CategoryNotification Insert(CategoryNotification entity)
        {
            return _CategoryNotificationRepository.Add(entity);
        }

        public void SaveChanges()
        {
            _unitOfWork.Commit();
        }

        public void Update(CategoryNotification entity)
        {
            _CategoryNotificationRepository.Update(entity);
        }
    }
}