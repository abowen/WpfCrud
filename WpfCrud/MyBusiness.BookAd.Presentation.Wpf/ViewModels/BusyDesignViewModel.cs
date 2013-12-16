using Caliburn.Micro;
using MyBusiness.BookAd.Presentation.Wpf.Interfaces;

namespace MyBusiness.BookAd.Presentation.Wpf.ViewModels
{
    public class BusyDesignViewModel : PropertyChangedBase, IBusyViewModel
    {
        private readonly string _busyMessage = "Loading";
        public string BusyMessage
        {
            get
            {
                return _busyMessage;
            }
        }

        private bool _isBusy = true;
        public bool IsBusy
        {
            get { return _isBusy; }
            set
            {
                _isBusy = value;
                NotifyOfPropertyChange(() => IsBusy);                
            }
        }
    }
}
