using System.Windows;
using System.Windows.Threading;
using MessageBox = Xceed.Wpf.Toolkit.MessageBox;

namespace MyBusiness.BookAd.Presentation.Wpf
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            DispatcherUnhandledException += OnDispatcherUnhandledException;
        }

        private void OnDispatcherUnhandledException(object sender, DispatcherUnhandledExceptionEventArgs dispatcherUnhandledExceptionEventArgs)
        {
            System.IO.File.WriteAllText(@".\UnhandledException.txt", dispatcherUnhandledExceptionEventArgs.Exception.ToString());

            var messageBox = new MessageBox {Text = "Unhandled Exception Thrown: Investigate UnhandledException.txt"};
            messageBox.ShowDialog();            
                        
            // Prevent default unhandled exception processing
            dispatcherUnhandledExceptionEventArgs.Handled = true;
        }

    }
}
