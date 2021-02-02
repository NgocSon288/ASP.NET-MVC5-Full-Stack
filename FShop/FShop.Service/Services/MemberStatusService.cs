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
    public interface IMemberStatusService
    {
        MemberStatus Insert(MemberStatus entity);

        void Update(MemberStatus entity);

        void Delete(MemberStatus entity);

        void Delete(int id);

        IEnumerable<MemberStatus> GetAll();

        IEnumerable<MemberStatus> GetAllPaging(int page, int pageSize, out int totalRow);

        MemberStatus GetByID(int id);

        void SaveChanges();

    }
    public class MemberStatusService : IMemberStatusService
    {
        private readonly IMemberStatusRepository _MemberStatusRepository;
        private readonly IUnitOfWork _unitOfWork;


        public MemberStatusService(IMemberStatusRepository MemberStatusRepository, IUnitOfWork unitOfWork)
        {
            this._MemberStatusRepository = MemberStatusRepository;
            this._unitOfWork = unitOfWork;
        }

        public void Delete(MemberStatus entity)
        {
            _MemberStatusRepository.Delete(entity);
        }

        public void Delete(int id)
        {
            _MemberStatusRepository.Delete(id);
        }

        public IEnumerable<MemberStatus> GetAll()
        {
            return _MemberStatusRepository.GetAll();
        }

        public IEnumerable<MemberStatus> GetAllPaging(int page, int pageSize, out int totalRow)
        {
            return _MemberStatusRepository.GetMultiPaging(ms => true, out totalRow, page, pageSize);
        }

        public MemberStatus GetByID(int id)
        {
            return _MemberStatusRepository.GetSingleById(id);
        }

        public MemberStatus Insert(MemberStatus entity)
        {
            return _MemberStatusRepository.Add(entity);
        }

        public void SaveChanges()
        {
            _unitOfWork.Commit();
        }

        public void Update(MemberStatus entity)
        {
            _MemberStatusRepository.Update(entity);
        }
    }
}
