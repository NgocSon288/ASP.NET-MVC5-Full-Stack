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
    public interface IPaymentMethodService
    {
        PaymentMethod Insert(PaymentMethod entity);

        void Update(PaymentMethod entity);

        void Delete(PaymentMethod entity);

        void Delete(int id);

        IEnumerable<PaymentMethod> GetAll();

        IEnumerable<PaymentMethod> GetAllPaging(int page, int pageSize, out int totalRow);

        PaymentMethod GetByID(int id);

        void SaveChanges();

    }
    public class PaymentMethodService : IPaymentMethodService
    {
        private readonly IPaymentMethodRepository _PaymentMethodRepository;
        private readonly IUnitOfWork _unitOfWork;


        public PaymentMethodService(IPaymentMethodRepository PaymentMethodRepository, IUnitOfWork unitOfWork)
        {
            this._PaymentMethodRepository = PaymentMethodRepository;
            this._unitOfWork = unitOfWork;
        }

        public void Delete(PaymentMethod entity)
        {
            _PaymentMethodRepository.Delete(entity);
        }

        public void Delete(int id)
        {
            _PaymentMethodRepository.Delete(id);
        }

        public IEnumerable<PaymentMethod> GetAll()
        {
            return _PaymentMethodRepository.GetAll();
        }

        public IEnumerable<PaymentMethod> GetAllPaging(int page, int pageSize, out int totalRow)
        {
            return _PaymentMethodRepository.GetMultiPaging(ms => true, out totalRow, page, pageSize);
        }

        public PaymentMethod GetByID(int id)
        {
            return _PaymentMethodRepository.GetSingleById(id);
        }

        public PaymentMethod Insert(PaymentMethod entity)
        {
            return _PaymentMethodRepository.Add(entity);
        }

        public void SaveChanges()
        {
            _unitOfWork.Commit();
        }

        public void Update(PaymentMethod entity)
        {
            _PaymentMethodRepository.Update(entity);
        }
    }
}
