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
    public interface INotificationService
    {
        Notification Insert(Notification entity);

        void Update(Notification entity);

        void Delete(Notification entity);

        void Delete(int id);

        IEnumerable<Notification> GetAll();

        IEnumerable<Notification> GetAllPaging(int page, int pageSize, out int totalRow);

        Notification GetByID(int id);

        void SaveChanges();

    }
    public class NotificationService : INotificationService
    {
        private readonly INotificationRepository _NotificationRepository;
        private readonly IUnitOfWork _unitOfWork;


        public NotificationService(INotificationRepository NotificationRepository, IUnitOfWork unitOfWork)
        {
            this._NotificationRepository = NotificationRepository;
            this._unitOfWork = unitOfWork;
        }

        public void Delete(Notification entity)
        {
            _NotificationRepository.Delete(entity);
        }

        public void Delete(int id)
        {
            _NotificationRepository.Delete(id);
        }

        public IEnumerable<Notification> GetAll()
        {
            return _NotificationRepository.GetAll();
        }

        public IEnumerable<Notification> GetAllPaging(int page, int pageSize, out int totalRow)
        {
            return _NotificationRepository.GetMultiPaging(ms => true, out totalRow, page, pageSize);
        }

        public Notification GetByID(int id)
        {
            return _NotificationRepository.GetSingleById(id);
        }

        public Notification Insert(Notification entity)
        {
            return _NotificationRepository.Add(entity);
        }

        public void SaveChanges()
        {
            _unitOfWork.Commit();
        }

        public void Update(Notification entity)
        {
            _NotificationRepository.Update(entity);
        }
    }
}
