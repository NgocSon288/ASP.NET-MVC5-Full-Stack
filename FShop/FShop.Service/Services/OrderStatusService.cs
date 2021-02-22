using FShop.Data.Infrastructure;
using FShop.Data.Repositories;
using FShop.Model.Models;
using System.Collections.Generic;

namespace FShop.Service.Services
{
    public interface IOrderStatusService
    {
        OrderStatus Insert(OrderStatus entity);

        void Update(OrderStatus entity);

        void Delete(OrderStatus entity);

        void Delete(int id);

        IEnumerable<OrderStatus> GetAll();

        IEnumerable<OrderStatus> GetAllPaging(int page, int pageSize, out int totalRow);

        OrderStatus GetByID(int id);

        void SaveChanges();
    }

    public class OrderStatusService : IOrderStatusService
    {
        private readonly IOrderStatusRepository _OrderStatusRepository;
        private readonly IUnitOfWork _unitOfWork;

        public OrderStatusService(IOrderStatusRepository OrderStatusRepository, IUnitOfWork unitOfWork)
        {
            this._OrderStatusRepository = OrderStatusRepository;
            this._unitOfWork = unitOfWork;
        }

        public void Delete(OrderStatus entity)
        {
            _OrderStatusRepository.Delete(entity);
        }

        public void Delete(int id)
        {
            _OrderStatusRepository.Delete(id);
        }

        public IEnumerable<OrderStatus> GetAll()
        {
            return _OrderStatusRepository.GetAll();
        }

        public IEnumerable<OrderStatus> GetAllPaging(int page, int pageSize, out int totalRow)
        {
            return _OrderStatusRepository.GetMultiPaging(ms => true, out totalRow, page, pageSize);
        }

        public OrderStatus GetByID(int id)
        {
            return _OrderStatusRepository.GetSingleById(id);
        }

        public OrderStatus Insert(OrderStatus entity)
        {
            return _OrderStatusRepository.Add(entity);
        }

        public void SaveChanges()
        {
            _unitOfWork.Commit();
        }

        public void Update(OrderStatus entity)
        {
            _OrderStatusRepository.Update(entity);
        }
    }
}