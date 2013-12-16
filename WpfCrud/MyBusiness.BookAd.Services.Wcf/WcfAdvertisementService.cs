using System.Collections.Generic;
using MyBusiness.BookAd.Business.Entities;
using MyBusiness.BookAd.Common;
using MyBusiness.BookAd.Common.Loggers;

namespace MyBusiness.BookAd.Services.Wcf
{    
    public class WcfAdvertisementService : IAdvertisementService
    {
        public WcfAdvertisementService()
        {
            var appConfigConfiguration = new AppConfigConfiguration();
            var logger = new BasicLog4NetLogger();
            _service = new AdvertisementService(appConfigConfiguration, logger);
        }

        private readonly AdvertisementService _service;

        public void AddAdvertisement(Advertisement value)
        {            
            _service.AddAdvertisement(value);
        }

        public IEnumerable<Advertisement> GetAdvertisements()
        {            
            return _service.GetAdvertisements();
        }
    }
}
