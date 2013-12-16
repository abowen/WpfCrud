using Caliburn.Micro;
using MyBusiness.BookAd.Presentation.Wpf.Interfaces;

namespace MyBusiness.BookAd.Presentation.Wpf.ViewModels
{
    public class ShellViewModel : Conductor<object>, IShell
    {        
        public ShellViewModel()
        {            
            NotificationViewModel = IoC.Get<NotificationViewModel>();
            DisplayName = "TV Commercial Reservation";
        }

        public NotificationViewModel NotificationViewModel { get; private set; }

        public void ShowListButton()
        {
            var listViewModel = IoC.Get<ListViewModel>();
            ActivateItem(listViewModel);
        }

        public void ShowAddButton()
        {
            var viewModel = IoC.Get<AddViewModel>();
            ActivateItem(viewModel);
        }
    }
}
