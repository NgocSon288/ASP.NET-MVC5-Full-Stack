using FShop.Data.Infrastructure;
using FShop.Data.Repositories;
using FShop.Model.Models;
using System.Collections.Generic;

namespace FShop.Service.Services
{
    public interface IOrderService
    {
        Order Insert(Order entity);

        void Update(Order entity);

        void Delete(Order entity);

        void Delete(int id);

        IEnumerable<Order> GetAll();

        IEnumerable<Order> GetAllPaging(int page, int pageSize, out int totalRow);

        Order GetByID(int id);

        void SaveChanges();
    }

    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _OrderRepository;
        private readonly IUnitOfWork _unitOfWork;

        public OrderService(IOrderRepository OrderRepository, IUnitOfWork unitOfWork)
        {
            this._OrderRepository = OrderRepository;
            this._unitOfWork = unitOfWork;
        }

        public void Delete(Order entity)
        {
            _OrderRepository.Delete(entity);
        }

        public void Delete(int id)
        {
            _OrderRepository.Delete(id);
        }

        public IEnumerable<Order> GetAll()
        {
            return _OrderRepository.GetAll();
        }

        public IEnumerable<Order> GetAllPaging(int page, int pageSize, out int totalRow)
        {
            return _OrderRepository.GetMultiPaging(ms => true, out totalRow, page, pageSize);
        }

        public Order GetByID(int id)
        {
            return _OrderRepository.GetSingleById(id);
        }

        public Order Insert(Order entity)
        {
            return _OrderRepository.Add(entity);
        }

        public void SaveChanges()
        {
            _unitOfWork.Commit();
        }

        public void Update(Order entity)
        {
            _OrderRepository.Update(entity);
        }
    }
}