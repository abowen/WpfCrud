using System.Collections.Generic;
using System.ServiceModel;
using MyBusiness.BookAd.Business.Entities;

namespace MyBusiness.BookAd.Services.Wcf
{    
    [ServiceContract]
    public interface IAdvertisementService
    {
        [OperationContract]
        void AddAdvertisement(Advertisement value);

        [OperationContract]
        IEnumerable<Advertisement> GetAdvertisements();
    } 
}
