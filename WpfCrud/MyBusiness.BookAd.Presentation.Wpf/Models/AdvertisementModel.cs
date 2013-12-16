using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Caliburn.Micro;
using MyBusiness.BookAd.Business.Entities;
using MyBusiness.BookAd.Presentation.Interfaces;

namespace MyBusiness.BookAd.Presentation.Wpf.Models
{
    public class AdvertisementModel : PropertyChangedBase
    {
        private readonly IAdvertisementAsyncService _service;
        private readonly Advertisement _advertisement;
        
        public AdvertisementModel(IAdvertisementAsyncService service, Advertisement advertisement = null)
        {            
            _advertisement = advertisement ?? new Advertisement();
            _service = service;
        }

        public DateTime BookingDateTimeLocal
        {
            get
            {
                return _advertisement.BookingDateTimeUtc.ToLocalTime();
            }
            set
            {
                _advertisement.BookingDateTimeUtc = value.ToUniversalTime();
                NotifyOfPropertyChange(() => BookingDateTimeLocal);
            }
        }

        public void ResetValues()
        {
            BookingDateTimeLocal = DateTime.Today.AddDays(1).AddHours(13);
            ClientName = string.Empty;
            DurationSeconds = 30;
        }

        public string ClientName
        {
            get
            {
                return _advertisement.ClientName;
            }
            set
            {
                _advertisement.ClientName = value;
                NotifyOfPropertyChange(() => ClientName);
            }
        }

        public int DurationSeconds
        {
            get
            {
                return _advertisement.DurationSeconds;
            }
            set
            {
                _advertisement.DurationSeconds = value;
                NotifyOfPropertyChange(() => DurationSeconds);
            }
        }

        private IEnumerable<string> _validationErrors = new string[0];
        public IEnumerable<string> ValidationErrors
        {
            get
            {
                return _validationErrors;
            }
            set
            {
                _validationErrors = value;
                NotifyOfPropertyChange(() => ValidationErrors);
            }
        }

        public bool IsValid
        {
            get
            {
                return _advertisement.IsValid;
            }
        }

        // This could be populated by a service
        private IEnumerable<int> _durations
        {
            get
            {
                return new[]
                {
                    15,
                    30,
                    45,
                    60
                };
            }
        }

        public IEnumerable<int> Durations { get { return _durations; } }


        public Task<Advertisement[]> GetAdvertisements()
        {            
            return _service.GetAdvertisementsAsync();
        }

        public Task SaveAsync()
        {
            ValidationErrors = _advertisement.GetValidationErrors();

            if (!ValidationErrors.Any())
            {                
                return _service.AddAdvertisementAsync(_advertisement);
            }
            
            return null;
        }
    }
}
