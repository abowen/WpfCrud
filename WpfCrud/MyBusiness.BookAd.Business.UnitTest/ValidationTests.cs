using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyBusiness.BookAd.Business.Entities;
using MyBusiness.BookAd.Business.Validation;

namespace MyBusiness.BookAd.Business.UnitTest
{
    [TestClass]
    public class ValidationTests
    {
        private static Advertisement GetValidAdvertisement()
        {
            var entity = new Advertisement
            {
                ClientName = "Valid Client Name",
                BookingDateTimeUtc = DateTime.UtcNow.AddDays(1),
                DurationSeconds = 15
            };
            return entity;
        }

        [TestMethod]
        public void Advertisement_With_Valid_Data_Returns_IsValid()
        {
            // ARRANGE
            var entity = GetValidAdvertisement();

            // ACT            

            // ASSERT            
            Assert.IsTrue(entity.IsValid);
        }

        [TestMethod]
        public void Advertisement_With_Valid_Data_Returns_No_Errors()
        {
            // ARRANGE
            var entity = GetValidAdvertisement();

            // ACT
            var errors = entity.GetValidationErrors();

            // ASSERT
            Assert.IsFalse(errors.Any());            
        }

        [TestMethod]
        public void Advertisement_With_Historic_BookingDate_Returns_Error()
        {
            // ARRANGE
            var entity = GetValidAdvertisement();
            entity.BookingDateTimeUtc = DateTime.UtcNow.AddDays(-1);

            // ACT
            var errors = entity.GetValidationErrors().ToArray();

            // ASSERT
            Assert.AreEqual(errors.Count(), 1);
            Assert.AreEqual(errors.First(), AdvertisementValidator.BookingDateGreaterThanNowErrorMessage);
        }

        [TestMethod]
        public void Advertisement_With_Zero_Duration_Returns_Error()
        {
            // ARRANGE
            var entity = GetValidAdvertisement();
            entity.DurationSeconds = 0;

            // ACT
            var errors = entity.GetValidationErrors().ToArray();

            // ASSERT
            Assert.AreEqual(errors.Count(), 1);
            Assert.AreEqual(errors.First(), AdvertisementValidator.DurationSecondsGreaterThanErrorMessage);
        }

        [TestMethod]
        public void Advertisement_With_Negative_Duration_Returns_Error()
        {
            // ARRANGE
            var entity = GetValidAdvertisement();
            entity.DurationSeconds = -1;

            // ACT
            var errors = entity.GetValidationErrors().ToArray();

            // ASSERT
            Assert.AreEqual(errors.Count(), 1);
            Assert.AreEqual(errors.First(), AdvertisementValidator.DurationSecondsGreaterThanErrorMessage);
        }

        [TestMethod]
        public void Advertisement_With_Client_Null_Returns_Error()
        {
            // ARRANGE
            var entity = GetValidAdvertisement();
            entity.ClientName = null;

            // ACT
            var errors = entity.GetValidationErrors().ToArray();

            // ASSERT
            Assert.AreEqual(errors.Count(), 1);
            Assert.AreEqual(errors.First(), AdvertisementValidator.ClientLengthErrorMessage);
        }

        [TestMethod]
        public void Advertisement_With_Client_StringEmpty_Returns_Error()
        {
            // ARRANGE
            var entity = GetValidAdvertisement();
            entity.ClientName = string.Empty;

            // ACT
            var errors = entity.GetValidationErrors().ToArray();

            // ASSERT
            Assert.AreEqual(errors.Count(), 1);
            Assert.AreEqual(errors.First(), AdvertisementValidator.ClientLengthErrorMessage);
        }

        [TestMethod]
        public void Advertisement_With_Client_101_Length_Returns_Error()
        {
            // ARRANGE
            var entity = GetValidAdvertisement();
            entity.ClientName = new string('c', 101);

            // ACT
            var errors = entity.GetValidationErrors().ToArray();

            // ASSERT
            Assert.AreEqual(errors.Count(), 1);
            Assert.AreEqual(errors.First(), AdvertisementValidator.ClientLengthErrorMessage);
        }
    }
}
