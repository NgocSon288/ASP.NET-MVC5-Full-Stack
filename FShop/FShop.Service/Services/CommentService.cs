using FShop.Data.Infrastructure;
using FShop.Data.Repositories;
using FShop.Model.Models;
using System.Collections.Generic;

namespace FShop.Service.Services
{
    public interface ICommentService
    {
        IEnumerable<Comment> GetByProductID(int productID);

        Comment Insert(Comment entity);

        void Update(Comment entity);

        void Delete(Comment entity);

        void Delete(int id);

        IEnumerable<Comment> GetAll();

        IEnumerable<Comment> GetAllPaging(int page, int pageSize, out int totalRow);

        Comment GetByID(int id);

        void SaveChanges();
    }

    public class CommentService : ICommentService
    {
        private readonly ICommentRepository _CommentRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CommentService(ICommentRepository CommentRepository, IUnitOfWork unitOfWork)
        {
            this._CommentRepository = CommentRepository;
            this._unitOfWork = unitOfWork;
        }

        public void Delete(Comment entity)
        {
            _CommentRepository.Delete(entity);
        }

        public void Delete(int id)
        {
            _CommentRepository.Delete(id);
        }

        public IEnumerable<Comment> GetAll()
        {
            return _CommentRepository.GetAll();
        }

        public IEnumerable<Comment> GetAllPaging(int page, int pageSize, out int totalRow)
        {
            return _CommentRepository.GetMultiPaging(ms => true, out totalRow, page, pageSize);
        }

        public Comment GetByID(int id)
        {
            return _CommentRepository.GetSingleById(id);
        }

        public IEnumerable<Comment> GetByProductID(int productID)
        {
            return _CommentRepository.GetMulti(c => c.ProductID == productID && c.Status == true);
        }

        public Comment Insert(Comment entity)
        {
            return _CommentRepository.Add(entity);
        }

        public void SaveChanges()
        {
            _unitOfWork.Commit();
        }

        public void Update(Comment entity)
        {
            _CommentRepository.Update(entity);
        }
    }
}