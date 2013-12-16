using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using MyBusiness.BookAd.Business.Interfaces;
using MyBusiness.BookAd.Common.Interfaces;
using BusinessObject = MyBusiness.BookAd.Business;

namespace MyBusiness.BookAd.Repository.EF
{
    public class AdvertisementRepository : IRepository<Business.Entities.Advertisement>
    {
        private readonly ILogger _logger;

        public AdvertisementRepository(ILogger logger)
        {
            _logger = logger;
        }

        [Conditional("DEBUG")]
        private void CheckConnection(BookAdEntities model)
        {
            //var databaseState = model.Database.Connection.State;
            //_logger.Debug(databaseState.ToString());
        }

        public void Create(Business.Entities.Advertisement entity)
        {
            var convertedEntity = ConvertTo(entity);
            using (var entityModel = new BookAdEntities())
            {
                CheckConnection(entityModel);
                entityModel.Advertisements.Add(convertedEntity);
                entityModel.SaveChanges();
            }
        }

        public Business.Entities.Advertisement Get(int id)
        {
            using (var entityModel = new BookAdEntities())
            {
                CheckConnection(entityModel);
                var entities = entityModel.Advertisements;
                return ConvertFrom(entities.Single(e => e.AdvertisementId == id));
            }
        }

        public IEnumerable<Business.Entities.Advertisement> GetAll()
        {
            using (var entityModel = new BookAdEntities())
            {
                CheckConnection(entityModel);
                var entities = entityModel.Advertisements;
                return entities.ToList().Select(ConvertFrom);
            }
        }

        public void Update(Business.Entities.Advertisement entity)
        {
            var convertedEntity = ConvertTo(entity);
            using (var entityModel = new BookAdEntities())
            {
                CheckConnection(entityModel);
                entityModel.Advertisements.Attach(convertedEntity);
                entityModel.SaveChanges();
            }
        }

        public void Delete(Business.Entities.Advertisement entity)
        {
            var convertedEntity = ConvertTo(entity);
            using (var entityModel = new BookAdEntities())
            {
                CheckConnection(entityModel);
                entityModel.Advertisements.Attach(convertedEntity);
                entityModel.Advertisements.Remove(convertedEntity);
                entityModel.SaveChanges();
            }
        }

        private static Advertisement ConvertTo(Business.Entities.Advertisement advertisement)
        {
            var convertedEntity = new Advertisement()
            {
                AdvertisementId = advertisement.AdvertisementId,
                BookingDateTimeUtc = advertisement.BookingDateTimeUtc,
                ClientName = advertisement.ClientName,
                DurationSeconds = advertisement.DurationSeconds
            };
            return convertedEntity;
        }

        private static Business.Entities.Advertisement ConvertFrom(Advertisement advertisement)
        {
            var convertedEntity = new Business.Entities.Advertisement()
            {
                AdvertisementId = advertisement.AdvertisementId,
                BookingDateTimeUtc = advertisement.BookingDateTimeUtc,
                ClientName = advertisement.ClientName,
                DurationSeconds = advertisement.DurationSeconds
            };
            return convertedEntity;
        }
    }
}
