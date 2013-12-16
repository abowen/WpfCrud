using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MyBusiness.BookAd.Repository.EF.UnitTest
{
    /// <summary>
    /// Ensures the EF model is working
    /// </summary>
    [TestClass]
    public class EntityFrameworkTests
    {
        [TestMethod]        
        public void EF_Can_Create_Advertisement()
        {
            // ARRANGE
            using (var entityModel = new BookAdEntities())
            {
                // ACT
                var advertisement = new Advertisement
                {
                    BookingDateTimeUtc = DateTime.UtcNow,
                    ClientName = "Test",
                    DurationSeconds = 60
                };

                // ASSERT
                entityModel.Advertisements.Add(advertisement);
                entityModel.SaveChanges();                
            }
        }

        [TestMethod]
        public void EF_Then_Can_Read_Advertisement()
        {
            // ARRANGE
            using (var entityModel = new BookAdEntities())
            {

                // ACT
                var values = entityModel.Advertisements.ToList();

                // ASSERT
                Assert.IsTrue(values.Any());
            }
        }

        [TestMethod]
        public void EF_Then_Can_Update_Advertisement()
        {
            // ARRANGE
            using (var entityModel = new BookAdEntities())
            {
                var values = entityModel.Advertisements.ToList();

                // ACT
                var value = values.First();
                value.ClientName = "Tester";

                // ASSERT
                entityModel.SaveChanges();
            }
        }

        [TestMethod]
        public void EF_Then_Can_Delete_Advertisement()
        {
            // ARRANGE
            using (var entityModel = new BookAdEntities())
            {
                var values = entityModel.Advertisements.ToList();

                // ACT
                var value = values.First();

                // ASSERT            
                entityModel.Advertisements.Remove(value);
                entityModel.SaveChanges();
            }
        }
    }
}
