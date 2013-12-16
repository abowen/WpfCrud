using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Media;
using Caliburn.Micro;
using MyBusiness.BookAd.Presentation.Wpf.Notifications;

namespace MyBusiness.BookAd.Presentation.Wpf.ViewModels
{
    public class NotificationViewModel : PropertyChangedBase, IHandle<NotificationEvent>
    {
        private readonly IEventAggregator _eventAggregator;

        public NotificationViewModel(IEventAggregator eventAggregator)
        {
            _eventAggregator = eventAggregator;
            _eventAggregator.Subscribe(this);
        }

        // Design purposes only
        public NotificationViewModel()
        {
            IsVisible = true;            
            Message = "Design Message Only";
            BackgroundBrush = new SolidColorBrush(Colors.Pink);
            ForegroundBrush = new SolidColorBrush(Colors.DarkBlue);
        }


        private string _message;
        public string Message
        {
            get { return _message; }
            set
            {
                _message = value;
                NotifyOfPropertyChange(() => Message);
            }
        }

        private Brush _backgroundBrush;
        public Brush BackgroundBrush
        {
            get { return _backgroundBrush; }
            set
            {
                _backgroundBrush = value;
                NotifyOfPropertyChange(() => BackgroundBrush);
            }
        }

        private Brush _foregroundBrush;
        public Brush ForegroundBrush
        {
            get { return _foregroundBrush; }
            set
            {
                _foregroundBrush = value;
                NotifyOfPropertyChange(() => ForegroundBrush);
            }
        }

        private bool _isVisible;

        public bool IsVisible
        {
            get { return _isVisible; }
            set
            {
                _isVisible = value;
                NotifyOfPropertyChange(() => IsVisible);
            }
        }

        public void Handle(NotificationEvent message)
        {            
            Message = message.Message;

            switch (message.Type)
            {
                case NotificationType.Success:
                    BackgroundBrush = new SolidColorBrush(Colors.Green);                    
                    ForegroundBrush = new SolidColorBrush(Colors.GhostWhite);
                    _messageTicks = 2000;
                    break;
                case NotificationType.Error:
                    BackgroundBrush = new SolidColorBrush(Colors.DarkRed);                    
                    ForegroundBrush = new SolidColorBrush(Colors.GhostWhite);
                    _messageTicks = 4000;
                    break;         
                default:
                    throw new Exception("Unknown Event Level Raised");
            }

            ShowNotification();
        }

        private int _messageTicks = 3000;

        async private void ShowNotification()
        {
            IsVisible = true;
            await Task.Run(() => Thread.Sleep(_messageTicks));
            IsVisible = false;
        }
    }
}
