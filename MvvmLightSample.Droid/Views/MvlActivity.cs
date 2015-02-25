using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Views;
using Microsoft.Practices.ServiceLocation;

namespace MvvmLightSample.Droid.Views
{
    public class MvlActivity<TViewModel> : ActivityBase 
        where TViewModel : ViewModelBase
    {
        private TViewModel _viewModel;
        public TViewModel ViewModel
        {
            get { return _viewModel; }
            set { _viewModel = value; }
        }

        public NavigationService GlobalNavigation
        {
            get
            {
                return (NavigationService)ServiceLocator.Current.GetInstance<INavigationService>();
            }
        }
    }
}