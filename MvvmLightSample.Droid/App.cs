using GalaSoft.MvvmLight.Ioc;
using GalaSoft.MvvmLight.Views;
using MvvmLightSample.Core.ViewModels;
using MvvmLightSample.Droid.Views;

namespace MvvmLightSample.Droid
{
    public static class App
    {
        private static ViewModelLocator _locator;

        public static ViewModelLocator Locator
        {
            get
            {
                if (_locator == null)
                {
                    // First time initialization
                    var nav = new NavigationService();
                    nav.Configure(
                        ViewModelLocator.DetailsPageKey,
                        typeof(SearchDetailActivity));

                    SimpleIoc.Default.Register<INavigationService>(() => nav);

                    _locator = new ViewModelLocator();
                }

                return _locator;
            }
        }
    }
}