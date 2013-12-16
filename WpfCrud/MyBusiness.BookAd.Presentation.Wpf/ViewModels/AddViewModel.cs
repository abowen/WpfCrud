using System.Threading.Tasks;
using Caliburn.Micro;
using MyBusiness.BookAd.Presentation.Interfaces;
using MyBusiness.BookAd.Presentation.Wpf.Globalization;
using MyBusiness.BookAd.Presentation.Wpf.Interfaces;
using MyBusiness.BookAd.Presentation.Wpf.Models;
using MyBusiness.BookAd.Presentation.Wpf.Notifications;

namespace MyBusiness.BookAd.Presentation.Wpf.ViewModels
{
    public class AddViewModel : PropertyChangedBase, IBusyViewModel
    {
        private readonly IEventAggregator _eventAggregator;        

        public AddViewModel(IEventAggregator eventAggregator, IAdvertisementAsyncService service)
        {
            _eventAggregator = eventAggregator;
            _advertisementModel = new AdvertisementModel(service);
            ResetValues();
        }        

        public void ClearButton()
        {
            ResetValues();
        }

        public bool CanClearButton { get { return !IsBusy; } }

        public void SubmitButton()
        {
            var task = _advertisementModel.SaveAsync();
            // Task returns null for validation errors
            if (task != null)
            {
                IsBusy = true;
                task.ContinueWith(AddAdvertisementCompleted);
            }
        }

        private void AddAdvertisementCompleted(Task completedTask)
        {
            if (completedTask.Exception == null)
            {
                var specialEvent = new NotificationEvent("Saved", NotificationType.Success);
                _eventAggregator.Publish(specialEvent);
            }
            else
            {
                var specialEvent = new NotificationEvent(ErrorMessages.ServerError, NotificationType.Error);
                _eventAggregator.Publish(specialEvent);
            }

            ResetValues();
            IsBusy = false;
        }

        public bool CanSubmitButton { get { return !IsBusy; } }

        private void ResetValues()
        {
            AdvertisementModel.ResetValues();
        }

        private AdvertisementModel _advertisementModel;
        public AdvertisementModel AdvertisementModel
        {
            get { return _advertisementModel; }
            set
            {
                _advertisementModel = value;
                NotifyOfPropertyChange(() => AdvertisementModel);
            }
        }


        private readonly string _busyMessage = "Saving";
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
                NotifyOfPropertyChange(() => CanSubmitButton);
                NotifyOfPropertyChange(() => CanClearButton);
            }
        }
    }
}
