namespace MyBusiness.BookAd.Presentation.Wpf.Notifications
{    
    public class NotificationEvent
    {
        public NotificationEvent(string message, NotificationType type)
        {            
            Message = message;
            Type = type;
        }

        public NotificationType Type { get; private set; }
        public string Message { get; private set; }        
    }
}
