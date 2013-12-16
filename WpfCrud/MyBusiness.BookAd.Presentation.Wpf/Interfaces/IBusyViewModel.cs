namespace MyBusiness.BookAd.Presentation.Wpf.Interfaces
{
    /// <summary>
    /// Used by ViewModels that want a Busy indicator on the UI
    /// </summary>
    public interface IBusyViewModel
    {
        bool IsBusy { get; }
        string BusyMessage { get; }
    }
}
