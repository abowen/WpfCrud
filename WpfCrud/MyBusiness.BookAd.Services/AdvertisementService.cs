using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Contracts;
using MyBusiness.BookAd.Business.Entities;
using MyBusiness.BookAd.Common.Interfaces;
using MyBusiness.BookAd.Repository;
using MyBusiness.BookAd.Services.Interfaces;

namespace MyBusiness.BookAd.Services
{
    /// <summary>
    /// This is the gateway for clients to access advertisement functionality
    /// </summary>
    /// <remarks>
    /// Does not provide StackTraces, etc of internal exceptions
    /// </remarks>
    public sealed class AdvertisementService : IAdvertisementService
    {
        private readonly IConfiguration _configuration;
        private readonly ILogger _logger;

        public AdvertisementService(IConfiguration configuration, ILogger logger)
        {
            Contract.Assert(configuration != null);
            Contract.Assert(logger != null);

            _configuration = configuration;
            _logger = logger;
        }

        public void AddAdvertisement(Advertisement advertisement)
        {
            const string logPrefix = "AdvertisementService: AddAdvertisement() ";

            try
            {
                _logger.Debug(logPrefix + advertisement);

                if (!advertisement.IsValid)
                {
                    var errorMessages = string.Join("\n", advertisement.GetValidationErrors());
                    throw new ValidationException("Validation errors: " + errorMessages);
                }

                var dataAccessFactory = new DataAccessFactory(_configuration.DataProvider, _logger);
                var advertisementRepository = dataAccessFactory.GetAdvertisementRepository();
                advertisementRepository.Create(advertisement);
            }
            catch (ValidationException ex)
            {
                _logger.Debug(logPrefix + ex);
                // I don't mind returning the StackTrace and errors for a validation error
                throw;
            }
            catch (Exception ex)
            {
                _logger.Error(logPrefix + ex);
                throw new Exception("Exception thrown. Check server logs");
            }
        }

        public IEnumerable<Advertisement> GetAdvertisements()
        {
            const string logPrefix = "AdvertisementService: GetAdvertisements() ";

            try
            {
                _logger.Debug(logPrefix);
                var dataAccessFactory = new DataAccessFactory(_configuration.DataProvider, _logger);
                var advertisementRepository = dataAccessFactory.GetAdvertisementRepository();
                return advertisementRepository.GetAll();
            }
            catch (Exception ex)
            {
                _logger.Error(logPrefix + ex);
                throw new Exception("Exception thrown. Check server logs");
            }
        }
    }
}
