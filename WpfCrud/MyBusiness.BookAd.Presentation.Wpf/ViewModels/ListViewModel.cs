using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Caliburn.Micro;
using MyBusiness.BookAd.Business.Entities;
using MyBusiness.BookAd.Presentation.Interfaces;
using MyBusiness.BookAd.Presentation.Wpf.Globalization;
using MyBusiness.BookAd.Presentation.Wpf.Interfaces;
using MyBusiness.BookAd.Presentation.Wpf.Models;
using MyBusiness.BookAd.Presentation.Wpf.Notifications;

namespace MyBusiness.BookAd.Presentation.Wpf.ViewModels
{
    public class ListViewModel : PropertyChangedBase, IBusyViewModel
    {
        private readonly IEventAggregator _eventAggregator;
        private readonly IAdvertisementAsyncService _service;
        private readonly AdvertisementModel _advertisementModel;

        public ListViewModel(IEventAggregator eventAggregator, IAdvertisementAsyncService service)
        {
            _eventAggregator = eventAggregator;
            _service = service;
            _advertisementModel = new AdvertisementModel(service);
            UpdateList();            
        }

        public void UpdateButton()
        {
            UpdateList();            
        }

        public bool CanUpdateButton
        {
            get
            {
                return !IsBusy;
            }
        }

        private void UpdateList()
        {
            IsBusy = true;
            _advertisementModel.GetAdvertisements().ContinueWith(GetAdvertisementsCompleted);
        }

        private void GetAdvertisementsCompleted(Task<Advertisement[]> completedTask)
        {
            try
            {
                var advertisments = completedTask.Result.ToList();
                advertisments.Sort();
                Advertisements = advertisments.Select(ad => new AdvertisementModel(_service, ad));
            }
            catch (Exception)
            {
                var specialEvent = new NotificationEvent(ErrorMessages.ServerError, NotificationType.Error);
                _eventAggregator.Publish(specialEvent);
            }
            finally
            {
                IsBusy = false;
            }
        }

        private readonly string _busyMessage = "Loading";
        public string BusyMessage
        {
            get
            {
                return _busyMessage;
            }
        }

        private bool _isBusy;
        public bool IsBusy
        {
            get { return _isBusy; }
            set
            {
                _isBusy = value;
                NotifyOfPropertyChange(() => IsBusy);
                NotifyOfPropertyChange(() => CanUpdateButton);
            }
        }


        private IEnumerable<AdvertisementModel> _advertisements = new List<AdvertisementModel>();

        public IEnumerable<AdvertisementModel> Advertisements
        {
            get { return _advertisements; }
            set
            {
                _advertisements = value;
                NotifyOfPropertyChange(() => Advertisements);
            }
        }
    }
}
