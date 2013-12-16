using System;
using System.Collections.Generic;
using Caliburn.Micro;
using MyBusiness.BookAd.Presentation.Interfaces;
using MyBusiness.BookAd.Presentation.Wcf;
using MyBusiness.BookAd.Presentation.Wpf.Interfaces;
using MyBusiness.BookAd.Presentation.Wpf.ViewModels;

namespace MyBusiness.BookAd.Presentation.Wpf
{
    public class AppBootstrapper : BootstrapperBase
    {
         private readonly SimpleContainer _container = new SimpleContainer();

         public AppBootstrapper()
         {
             Start();
         }

        protected override void Configure()
        {
            _container.Singleton<IWindowManager, WindowManager>();
            _container.Singleton<IEventAggregator, EventAggregator>();
            _container.Singleton<NotificationViewModel>();
            _container.Singleton<IShell, ShellViewModel>();

            _container.RegisterPerRequest(typeof(ListViewModel), "ListViewModel", typeof(ListViewModel));
            _container.RegisterPerRequest(typeof(AddViewModel), "AddViewModel", typeof(AddViewModel));
            _container.RegisterPerRequest(typeof(IAdvertisementAsyncService), "AdvertisementAsyncService", typeof(AdvertisementAsyncService));
        }        

        protected override object GetInstance(Type service, string key)
        {
            var instance = _container.GetInstance(service, key);
            if (instance != null)
                return instance;

            throw new InvalidOperationException("Could not locate any instances.");
        }

        protected override IEnumerable<object> GetAllInstances(Type service)
        {
            return _container.GetAllInstances(service);
        }

        protected override void BuildUp(object instance)
        {
            _container.BuildUp(instance);
        }

        protected override void OnStartup(object sender, System.Windows.StartupEventArgs e)
        {
            DisplayRootViewFor<IShell>();
        }
    }
}
