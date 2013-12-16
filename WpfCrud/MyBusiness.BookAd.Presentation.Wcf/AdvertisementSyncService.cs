using MyBusiness.BookAd.Business.Entities;
using MyBusiness.BookAd.Presentation.Interfaces;
using Service = MyBusiness.BookAd.Presentation.Wcf.AdvertisementServiceReference;

namespace MyBusiness.BookAd.Presentation.Wcf
{
    public class AdvertisementSyncService : IAdvertisementSyncService
    {
        public Advertisement[] GetAdvertisements()
        {
            var client = new AdvertisementServiceReference.AdvertisementServiceClient();                        
            var clientTask = client.GetAdvertisementsAsync();
            return clientTask.Result;
        }

        public void AddAdvertisement(Advertisement advertisement)
        {
            var client = new AdvertisementServiceReference.AdvertisementServiceClient();            
            var clientTask = client.AddAdvertisementAsync(advertisement);
            clientTask.Wait();
        }        
    }
}
