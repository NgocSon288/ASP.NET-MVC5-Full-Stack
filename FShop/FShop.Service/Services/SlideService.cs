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
    public interface ISlideService
    {
        Slide Insert(Slide entity);

        void Update(Slide entity);

        void Delete(Slide entity);

        void Delete(int id);

        IEnumerable<Slide> GetAll();

        IEnumerable<Slide> GetAllPaging(int page, int pageSize, out int totalRow);

        Slide GetByID(int id);

        void SaveChanges();

    }
    public class SlideService : ISlideService
    {
        private readonly ISlideRepository _SlideRepository;
        private readonly IUnitOfWork _unitOfWork;


        public SlideService(ISlideRepository SlideRepository, IUnitOfWork unitOfWork)
        {
            this._SlideRepository = SlideRepository;
            this._unitOfWork = unitOfWork;
        }

        public void Delete(Slide entity)
        {
            _SlideRepository.Delete(entity);
        }

        public void Delete(int id)
        {
            _SlideRepository.Delete(id);
        }

        public IEnumerable<Slide> GetAll()
        {
            return _SlideRepository.GetAll();
        }

        public IEnumerable<Slide> GetAllPaging(int page, int pageSize, out int totalRow)
        {
            return _SlideRepository.GetMultiPaging(ms => true, out totalRow, page, pageSize);
        }

        public Slide GetByID(int id)
        {
            return _SlideRepository.GetSingleById(id);
        }

        public Slide Insert(Slide entity)
        {
            return _SlideRepository.Add(entity);
        }

        public void SaveChanges()
        {
            _unitOfWork.Commit();
        }

        public void Update(Slide entity)
        {
            _SlideRepository.Update(entity);
        }
    }
}
