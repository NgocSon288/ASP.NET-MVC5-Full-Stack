using FShop.Data.Infrastructure;
using FShop.Data.Repositories;
using FShop.Model.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FShop.Test.RepositoryTest
{
    [TestClass]
    public class AdvertisementRepositoryTest
    {
        private IDbFactory dbFactory;
        private IAdvertisementRepository advertisementRepository;
        private IUnitOfWork unitOfWork;

        [TestInitialize]
        public void Initialize()
        {
            dbFactory = new DbFactory();
            advertisementRepository = new AdvertisementRepository(dbFactory);
            unitOfWork = new UnitOfWork(dbFactory);
        }

        [TestMethod]
        public void Advertisement_Repository_Create()
        {
            Advertisement advertisement = new Advertisement();
            advertisement.Description = "Description";
            advertisement.DisplayOrder = 0;
            advertisement.Image = "Image";
            advertisement.Name = "Name";
            advertisement.Status = false;
            advertisement.URL = "URL";

            var result = advertisementRepository.Add(advertisement);
            unitOfWork.Commit();

            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.ID);
        } 
    }
}