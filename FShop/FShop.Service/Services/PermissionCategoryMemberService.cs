using FShop.Data.Infrastructure;
using FShop.Data.Repositories;
using FShop.Model.Models;
using System.Collections.Generic;

namespace FShop.Service.Services
{
    public interface IPermissionCategoryMemberService
    {
        PermissionCategoryMember Insert(PermissionCategoryMember entity);

        void Update(PermissionCategoryMember entity);

        void Delete(PermissionCategoryMember entity);

        void Delete(int id);

        IEnumerable<PermissionCategoryMember> GetAll();

        IEnumerable<PermissionCategoryMember> GetAllPaging(int page, int pageSize, out int totalRow);

        PermissionCategoryMember GetByID(int id);

        void SaveChanges();
    }

    public class PermissionCategoryMemberService : IPermissionCategoryMemberService
    {
        private readonly IPermissionCategoryMemberRepository _PermissionCategoryMemberRepository;
        private readonly IUnitOfWork _unitOfWork;

        public PermissionCategoryMemberService(IPermissionCategoryMemberRepository PermissionCategoryMemberRepository, IUnitOfWork unitOfWork)
        {
            this._PermissionCategoryMemberRepository = PermissionCategoryMemberRepository;
            this._unitOfWork = unitOfWork;
        }

        public void Delete(PermissionCategoryMember entity)
        {
            _PermissionCategoryMemberRepository.Delete(entity);
        }

        public void Delete(int id)
        {
            _PermissionCategoryMemberRepository.Delete(id);
        }

        public IEnumerable<PermissionCategoryMember> GetAll()
        {
            return _PermissionCategoryMemberRepository.GetAll();
        }

        public IEnumerable<PermissionCategoryMember> GetAllPaging(int page, int pageSize, out int totalRow)
        {
            return _PermissionCategoryMemberRepository.GetMultiPaging(ms => true, out totalRow, page, pageSize);
        }

        public PermissionCategoryMember GetByID(int id)
        {
            return _PermissionCategoryMemberRepository.GetSingleById(id);
        }

        public PermissionCategoryMember Insert(PermissionCategoryMember entity)
        {
            return _PermissionCategoryMemberRepository.Add(entity);
        }

        public void SaveChanges()
        {
            _unitOfWork.Commit();
        }

        public void Update(PermissionCategoryMember entity)
        {
            _PermissionCategoryMemberRepository.Update(entity);
        }
    }
}