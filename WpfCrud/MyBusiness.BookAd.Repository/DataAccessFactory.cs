using System;
using MyBusiness.BookAd.Business.Entities;
using MyBusiness.BookAd.Business.Interfaces;
using MyBusiness.BookAd.Common.Interfaces;

namespace MyBusiness.BookAd.Repository
{    
    public class DataAccessFactory
    {
        private readonly string _dataSource;
        private readonly ILogger _logger;

        public DataAccessFactory(string dataSource, ILogger logger)
        {
            if (string.IsNullOrWhiteSpace(dataSource))
            {
                throw new ArgumentNullException("dataSource", "No data source information");
            }
            _dataSource = dataSource;
            _logger = logger;
        }

        public IRepository<Advertisement> GetAdvertisementRepository()
        {
            switch (_dataSource.ToUpper())
            {
                case "ENTITYFRAMEWORK":
                    return new EF.AdvertisementRepository(_logger);
                default:
                    var errorMessage = string.Format("Data Source of {0} not found", _dataSource);
                    throw new NotImplementedException(errorMessage);
            }            
        }
    }
}
