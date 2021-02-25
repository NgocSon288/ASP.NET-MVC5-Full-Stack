using FShop.Data.Infrastructure;
using FShop.Data.Repositories;
using FShop.Model.Models;
using System.Collections.Generic;

namespace FShop.Service.Services
{
    public interface IPermissionCategoryMemberService
    {
        IEnumerable<PermissionCategoryMember> GetPermissionCategoryMembers(int categoryMemberID);

        bool InsertOrDelete(PermissionCategoryMember permission);

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

        public IEnumerable<PermissionCategoryMember> GetPermissionCategoryMembers(int categoryMemberID)
        {
            return _PermissionCategoryMemberRepository.GetMulti(p => p.CategoryMemberID == categoryMemberID);
        }

        public PermissionCategoryMember Insert(PermissionCategoryMember entity)
        {
            return _PermissionCategoryMemberRepository.Add(entity);
        }

        public bool InsertOrDelete(PermissionCategoryMember permission)
        {
            try
            {
                var permissionCategoryMember = _PermissionCategoryMemberRepository.GetSingleByCondition(p => p.PermissionID == permission.PermissionID && p.CategoryMemberID == permission.CategoryMemberID);

                if (permissionCategoryMember != null)
                {
                    _PermissionCategoryMemberRepository.Delete(permissionCategoryMember);
                }
                else
                {
                    _PermissionCategoryMemberRepository.Add(permission);
                }

                return true;
            }
            catch (System.Exception)
            {
                return false;
            }
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