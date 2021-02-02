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
    public interface IMemberService
    {
        Member Insert(Member entity);

        void Update(Member entity);

        void Delete(Member entity);

        void Delete(int id);

        IEnumerable<Member> GetAll();

        IEnumerable<Member> GetAllPaging(int page, int pageSize, out int totalRow);

        Member GetByID(int id);

        void SaveChanges();

    }
    public class MemberService : IMemberService
    {
        private readonly IMemberRepository _MemberRepository;
        private readonly IUnitOfWork _unitOfWork;


        public MemberService(IMemberRepository MemberRepository, IUnitOfWork unitOfWork)
        {
            this._MemberRepository = MemberRepository;
            this._unitOfWork = unitOfWork;
        }

        public void Delete(Member entity)
        {
            _MemberRepository.Delete(entity);
        }

        public void Delete(int id)
        {
            _MemberRepository.Delete(id);
        }

        public IEnumerable<Member> GetAll()
        {
            return _MemberRepository.GetAll();
        }

        public IEnumerable<Member> GetAllPaging(int page, int pageSize, out int totalRow)
        {
            return _MemberRepository.GetMultiPaging(ms => true, out totalRow, page, pageSize);
        }

        public Member GetByID(int id)
        {
            return _MemberRepository.GetSingleById(id);
        }

        public Member Insert(Member entity)
        {
            return _MemberRepository.Add(entity);
        }

        public void SaveChanges()
        {
            _unitOfWork.Commit();
        }

        public void Update(Member entity)
        {
            _MemberRepository.Update(entity);
        }
    }
}
