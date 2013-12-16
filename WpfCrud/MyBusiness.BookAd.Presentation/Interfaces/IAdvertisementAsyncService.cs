using System.Threading.Tasks;
using MyBusiness.BookAd.Business.Entities;

namespace MyBusiness.BookAd.Presentation.Interfaces
{
    public interface IAdvertisementAsyncService
    {                
        Task AddAdvertisementAsync(Advertisement value);
        Task<Advertisement[]> GetAdvertisementsAsync();
    }
}
