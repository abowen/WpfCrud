using MyBusiness.BookAd.Business;
using MyBusiness.BookAd.Business.Entities;

namespace MyBusiness.BookAd.Presentation.Interfaces
{
    public interface IAdvertisementSyncService
    {                
        void AddAdvertisement(Advertisement value);
        Advertisement[] GetAdvertisements();
    }
}
