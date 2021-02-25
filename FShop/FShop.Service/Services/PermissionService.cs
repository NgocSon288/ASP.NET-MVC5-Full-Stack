using FShop.Data.Infrastructure;
using FShop.Data.Repositories;
using FShop.Model.Models;
using System.Collections.Generic;

namespace FShop.Service.Services
{
    public interface IPermissionService
    {  
        Permission Insert(Permission entity);

        void Update(Permission entity);

        void Delete(Permission entity);

        void Delete(int id);

        IEnumerable<Permission> GetAll();

        IEnumerable<Permission> GetAllPaging(int page, int pageSize, out int totalRow);

        Permission GetByID(int id);

        void SaveChanges();
    }

    public class PermissionService : IPermissionService
    {
        private readonly IPermissionRepository _PermissionRepository;
        private readonly IUnitOfWork _unitOfWork;

        public PermissionService(IPermissionRepository PermissionRepository, IUnitOfWork unitOfWork)
        {
            this._PermissionRepository = PermissionRepository;
            this._unitOfWork = unitOfWork;
        }

        public void Delete(Permission entity)
        {
            _PermissionRepository.Delete(entity);
        }

        public void Delete(int id)
        {
            _PermissionRepository.Delete(id);
        }

        public IEnumerable<Permission> GetAll()
        {
            return _PermissionRepository.GetAll();
        }

        public IEnumerable<Permission> GetAllPaging(int page, int pageSize, out int totalRow)
        {
            return _PermissionRepository.GetMultiPaging(ms => true, out totalRow, page, pageSize);
        }
         
        public Permission GetByID(int id)
        {
            return _PermissionRepository.GetSingleById(id);
        }

        public Permission Insert(Permission entity)
        {
            return _PermissionRepository.Add(entity);
        }

        public void SaveChanges()
        {
            _unitOfWork.Commit();
        }

        public void Update(Permission entity)
        {
            _PermissionRepository.Update(entity);
        }
    }
}