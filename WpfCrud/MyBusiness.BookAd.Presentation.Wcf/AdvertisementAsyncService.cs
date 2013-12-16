using System.Threading.Tasks;
using MyBusiness.BookAd.Business.Entities;
using MyBusiness.BookAd.Presentation.Interfaces;
using Service = MyBusiness.BookAd.Presentation.Wcf.AdvertisementServiceReference;

namespace MyBusiness.BookAd.Presentation.Wcf
{
    public class AdvertisementAsyncService : IAdvertisementAsyncService
    {
        public async Task AddAdvertisementAsync(Advertisement value)
        {
            using (var service = new Service.AdvertisementServiceClient())
            {
                await service.AddAdvertisementAsync(value);
            }
        }

        public async Task<Advertisement[]> GetAdvertisementsAsync()
        {
            using (var service = new Service.AdvertisementServiceClient())
            {
                return await service.GetAdvertisementsAsync();
            }
        }
    }
}
