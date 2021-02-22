using FShop.Data.Infrastructure;
using FShop.Data.Repositories;
using FShop.Model.Models;
using System.Collections.Generic;

namespace FShop.Service.Services
{
    public interface ICategoryMemberService
    {
        CategoryMember Insert(CategoryMember entity);

        void Update(CategoryMember entity);

        void Delete(CategoryMember entity);

        void Delete(int id);

        IEnumerable<CategoryMember> GetAll();

        IEnumerable<CategoryMember> GetAllPaging(int page, int pageSize, out int totalRow);

        CategoryMember GetByID(int id);

        void SaveChanges();
    }

    public class CategoryMemberService : ICategoryMemberService
    {
        private readonly ICategoryMemberRepository _CategoryMemberRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CategoryMemberService(ICategoryMemberRepository CategoryMemberRepository, IUnitOfWork unitOfWork)
        {
            this._CategoryMemberRepository = CategoryMemberRepository;
            this._unitOfWork = unitOfWork;
        }

        public void Delete(CategoryMember entity)
        {
            _CategoryMemberRepository.Delete(entity);
        }

        public void Delete(int id)
        {
            _CategoryMemberRepository.Delete(id);
        }

        public IEnumerable<CategoryMember> GetAll()
        {
            return _CategoryMemberRepository.GetAll();
        }

        public IEnumerable<CategoryMember> GetAllPaging(int page, int pageSize, out int totalRow)
        {
            return _CategoryMemberRepository.GetMultiPaging(ms => true, out totalRow, page, pageSize);
        }

        public CategoryMember GetByID(int id)
        {
            return _CategoryMemberRepository.GetSingleById(id);
        }

        public CategoryMember Insert(CategoryMember entity)
        {
            return _CategoryMemberRepository.Add(entity);
        }

        public void SaveChanges()
        {
            _unitOfWork.Commit();
        }

        public void Update(CategoryMember entity)
        {
            _CategoryMemberRepository.Update(entity);
        }
    }
}