﻿using FShop.Data.Infrastructure;
using FShop.Data.Repositories;
using FShop.Model.Models;
using System.Collections.Generic;

namespace FShop.Service.Services
{
    public interface IImportBillDetailService
    {
        void DeleteByImportBillID(int importBillID);

        IEnumerable<ImportBillDetail> GetByImportBillID(int importBillID);

        ImportBillDetail Insert(ImportBillDetail entity);

        void Insert(IEnumerable<ImportBillDetail> importBillDetails);

        void Update(ImportBillDetail entity);

        void Delete(ImportBillDetail entity);

        void Delete(int id);

        IEnumerable<ImportBillDetail> GetAll();

        IEnumerable<ImportBillDetail> GetAllPaging(int page, int pageSize, out int totalRow);

        ImportBillDetail GetByID(int id);

        void SaveChanges();
    }

    public class ImportBillDetailService : IImportBillDetailService
    {
        private readonly IImportBillDetailRepository _ImportBillDetailRepository;
        private readonly IUnitOfWork _unitOfWork;

        public ImportBillDetailService(IImportBillDetailRepository ImportBillDetailRepository, IUnitOfWork unitOfWork)
        {
            this._ImportBillDetailRepository = ImportBillDetailRepository;
            this._unitOfWork = unitOfWork;
        }

        public void Delete(ImportBillDetail entity)
        {
            _ImportBillDetailRepository.Delete(entity);
        }

        public void Delete(int id)
        {
            _ImportBillDetailRepository.Delete(id);
        }

        public void DeleteByImportBillID(int importBillID)
        {
            _ImportBillDetailRepository.DeleteMulti(ibd => ibd.ImportBillID == importBillID);
        }

        public IEnumerable<ImportBillDetail> GetAll()
        {
            return _ImportBillDetailRepository.GetAll();
        }

        public IEnumerable<ImportBillDetail> GetAllPaging(int page, int pageSize, out int totalRow)
        {
            return _ImportBillDetailRepository.GetMultiPaging(ms => true, out totalRow, page, pageSize);
        }

        public ImportBillDetail GetByID(int id)
        {
            return _ImportBillDetailRepository.GetSingleById(id);
        }

        public IEnumerable<ImportBillDetail> GetByImportBillID(int importBillID)
        {
            return _ImportBillDetailRepository.GetMulti((ibd => ibd.ImportBillID == importBillID));
        }

        public ImportBillDetail Insert(ImportBillDetail entity)
        {
            return _ImportBillDetailRepository.Add(entity);
        }

        public void Insert(IEnumerable<ImportBillDetail> importBillDetails)
        {
            foreach (var item in importBillDetails)
            {
                _ImportBillDetailRepository.Add(item);
            }
        }

        public void SaveChanges()
        {
            _unitOfWork.Commit();
        }

        public void Update(ImportBillDetail entity)
        {
            _ImportBillDetailRepository.Update(entity);
        }
    }
}