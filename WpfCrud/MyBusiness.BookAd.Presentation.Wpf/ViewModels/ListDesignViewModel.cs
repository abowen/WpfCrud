using System;
using System.Collections.Generic;
using Caliburn.Micro;
using MyBusiness.BookAd.Business.Entities;

namespace MyBusiness.BookAd.Presentation.Wpf.ViewModels
{
    public class ListDesignViewModel : PropertyChangedBase
    {
        public ListDesignViewModel()
        {
            UpdateList();
        }

        public void UpdateButton()
        {
            UpdateList();
        }

        protected void UpdateList()
        {
            IsLoading = true;
            var advertisements = new List<Advertisement>
            {
                new Advertisement { AdvertisementId = 1, BookingDateTimeUtc = DateTime.UtcNow, ClientName = "Andrew Bowen", DurationSeconds = 45},
                new Advertisement { AdvertisementId = 2, BookingDateTimeUtc = DateTime.UtcNow.AddHours(-6), ClientName = "James Brown", DurationSeconds = 60},
                new Advertisement { AdvertisementId = 3, BookingDateTimeUtc = DateTime.UtcNow.AddHours(-12), ClientName = "Jinni Marks", DurationSeconds = 30},
                new Advertisement { AdvertisementId = 4, BookingDateTimeUtc = DateTime.UtcNow.AddHours(-18), ClientName = "Fran Sandra", DurationSeconds = 15},
            };
            Advertisements = advertisements;
            IsLoading = false;
        }

        private bool _isLoading;
        public bool IsLoading
        {
            get { return _isLoading; }
            set
            {
                _isLoading = value;
                NotifyOfPropertyChange(() => IsLoading);
            }
        }

        private List<Advertisement> _advertisements = new List<Advertisement>();
        public List<Advertisement> Advertisements
        {
            get { return _advertisements; }
            set
            {
                _advertisements = value;
                _advertisements.Sort();
                NotifyOfPropertyChange(() => Advertisements);
            }
        }
    }
}
