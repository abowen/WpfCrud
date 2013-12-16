using System.Collections.Generic;
using MyBusiness.BookAd.Business.Entities;

namespace MyBusiness.BookAd.Services.Interfaces
{
    public interface IAdvertisementService
    {
        void AddAdvertisement(Advertisement advertisement);        
        IEnumerable<Advertisement> GetAdvertisements();
    }
}
