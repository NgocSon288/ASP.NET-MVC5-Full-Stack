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
    public interface IMemberNotificationService
    {
        MemberNotification Insert(MemberNotification entity);

        void Update(MemberNotification entity);

        void Delete(MemberNotification entity);

        void Delete(int id);

        IEnumerable<MemberNotification> GetAll();

        IEnumerable<MemberNotification> GetAllPaging(int page, int pageSize, out int totalRow);

        MemberNotification GetByID(int id);

        void SaveChanges();

    }
    public class MemberNotificationService : IMemberNotificationService
    {
        private readonly IMemberNotificationRepository _MemberNotificationRepository;
        private readonly IUnitOfWork _unitOfWork;


        public MemberNotificationService(IMemberNotificationRepository MemberNotificationRepository, IUnitOfWork unitOfWork)
        {
            this._MemberNotificationRepository = MemberNotificationRepository;
            this._unitOfWork = unitOfWork;
        }

        public void Delete(MemberNotification entity)
        {
            _MemberNotificationRepository.Delete(entity);
        }

        public void Delete(int id)
        {
            _MemberNotificationRepository.Delete(id);
        }

        public IEnumerable<MemberNotification> GetAll()
        {
            return _MemberNotificationRepository.GetAll();
        }

        public IEnumerable<MemberNotification> GetAllPaging(int page, int pageSize, out int totalRow)
        {
            return _MemberNotificationRepository.GetMultiPaging(ms => true, out totalRow, page, pageSize);
        }

        public MemberNotification GetByID(int id)
        {
            return _MemberNotificationRepository.GetSingleById(id);
        }

        public MemberNotification Insert(MemberNotification entity)
        {
            return _MemberNotificationRepository.Add(entity);
        }

        public void SaveChanges()
        {
            _unitOfWork.Commit();
        }

        public void Update(MemberNotification entity)
        {
            _MemberNotificationRepository.Update(entity);
        }
    }
}
