using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyBusiness.BookAd.Common;
using MyBusiness.BookAd.Common.UnitTest;

namespace MyBusiness.BookAd.Repository.UnitTest
{
    /// <summary>
    /// Tests the mapping of BusinessEntities -> EntityFramework
    /// </summary>
    [TestClass]
    public class RepositoryTests
    {
        public RepositoryTests()
        {
            var appConfiguration = new AppConfigConfiguration();
            var debugLogger = new DebugLogger();
            _factory = new DataAccessFactory(appConfiguration.DataProvider, debugLogger);
        }

        private readonly DataAccessFactory _factory;

        [TestMethod]
        public void Repo_Can_Create_Advertisement()
        {
            // ARRANGE
            var repository = _factory.GetAdvertisementRepository();

            var entity = new Business.Entities.Advertisement
            {
                BookingDateTimeUtc = DateTime.UtcNow,
                ClientName = "Test",
                DurationSeconds = 60
            };

            // ACT
            repository.Create(entity);

            // ASSERT            
        }

        [TestMethod]
        public void Repo_Then_Can_Read_Advertisement()
        {
            // ARRANGE
            var repository = _factory.GetAdvertisementRepository();

            // ACT
            var entities = repository.GetAll();

            // ASSERT
            Assert.IsTrue(entities.Any());
        }

        [TestMethod]
        public void Repo_Then_Can_Update_Advertisement()
        {
            // ARRANGE
            var repository = _factory.GetAdvertisementRepository();
            var entity = repository.GetAll().First();
            entity.ClientName = "Tester";

            // ACT                        
            repository.Update(entity);

            // ASSERT

        }

        [TestMethod]
        public void Repo_Then_Can_Delete_Advertisement()
        {
            // ARRANGE
            var repository = _factory.GetAdvertisementRepository();
            var entity = repository.GetAll().First();

            // ACT
            repository.Delete(entity);

            // ASSERT                                    
        }
    }
}
