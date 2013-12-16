using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyBusiness.BookAd.Common;
using MyBusiness.BookAd.Common.Interfaces;
using MyBusiness.BookAd.Common.UnitTest;


namespace MyBusiness.BookAd.Services.UnitTest
{        
    [TestClass]
    public class ServiceTests
    {
        public ServiceTests()
        {
            IConfiguration configuration = new AppConfigConfiguration();
            ILogger logger = new DebugLogger();
            _service = new AdvertisementService(configuration, logger);
        }

        private readonly AdvertisementService _service;

        [TestMethod]
        public void Service_Can_Create_Advertisement()
        {
            // ARRANGE
            var entity = new Business.Entities.Advertisement
            {
                BookingDateTimeUtc = DateTime.UtcNow.AddDays(1),
                ClientName = "Test",
                DurationSeconds = 60
            };

            // ACT
            _service.AddAdvertisement(entity);

            // ASSERT            
        }

        [TestMethod]
        public void Service_Then_Can_GetAdvertisements()
        {
            // ARRANGE            

            // ACT
            var entities = _service.GetAdvertisements();

            // ASSERT
            Assert.IsTrue(entities.Any());
        }

        [TestMethod, ExpectedException(typeof(ValidationException))]
        public void Service_Ensures_Advertisement_Validation()
        {
            // ARRANGE            
            var entity = new Business.Entities.Advertisement
            {
                BookingDateTimeUtc = DateTime.UtcNow.AddDays(-1),
                ClientName = string.Empty,
                DurationSeconds = -1
            };

            // ACT
            _service.AddAdvertisement(entity);

            // ASSERT  
            Assert.Fail("Test should never get here");
        }   
    }
}
