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
    public interface IOrderDetailService
    {
        OrderDetail Insert(OrderDetail entity);

        void Update(OrderDetail entity);

        void Delete(OrderDetail entity);

        void Delete(int id);

        IEnumerable<OrderDetail> GetAll();

        IEnumerable<OrderDetail> GetAllPaging(int page, int pageSize, out int totalRow);

        OrderDetail GetByID(int id);

        void SaveChanges();

    }
    public class OrderDetailService : IOrderDetailService
    {
        private readonly IOrderDetailRepository _OrderDetailRepository;
        private readonly IUnitOfWork _unitOfWork;


        public OrderDetailService(IOrderDetailRepository OrderDetailRepository, IUnitOfWork unitOfWork)
        {
            this._OrderDetailRepository = OrderDetailRepository;
            this._unitOfWork = unitOfWork;
        }

        public void Delete(OrderDetail entity)
        {
            _OrderDetailRepository.Delete(entity);
        }

        public void Delete(int id)
        {
            _OrderDetailRepository.Delete(id);
        }

        public IEnumerable<OrderDetail> GetAll()
        {
            return _OrderDetailRepository.GetAll();
        }

        public IEnumerable<OrderDetail> GetAllPaging(int page, int pageSize, out int totalRow)
        {
            return _OrderDetailRepository.GetMultiPaging(ms => true, out totalRow, page, pageSize);
        }

        public OrderDetail GetByID(int id)
        {
            return _OrderDetailRepository.GetSingleById(id);
        }

        public OrderDetail Insert(OrderDetail entity)
        {
            return _OrderDetailRepository.Add(entity);
        }

        public void SaveChanges()
        {
            _unitOfWork.Commit();
        }

        public void Update(OrderDetail entity)
        {
            _OrderDetailRepository.Update(entity);
        }
    }
}
