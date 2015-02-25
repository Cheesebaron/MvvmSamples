using Android.App;
using Android.OS;
using Android.Widget;
using Cirrious.MvvmCross.Droid.Views;
using MvxSample.Core.Services;
using MvxSample.Core.ViewModels;

namespace MvxSample.Droid.Views
{
    [Activity(Label = "Search")]
    public class SearchView : MvxActivity<SearchViewModel>, ActionBar.IOnNavigationListener
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.SearchView);

            ActionBar.NavigationMode = ActionBarNavigationMode.List;

            var adapter = new ArrayAdapter<SearchProvider>(this, Android.Resource.Layout.SimpleSpinnerItem,
                ViewModel.SearchProviders);

            ActionBar.SetListNavigationCallbacks(adapter, this);
            ActionBar.SetSelectedNavigationItem(0);
        }

        public bool OnNavigationItemSelected(int itemPosition, long itemId)
        {
            ViewModel.SelectedSearchProvider = ViewModel.SearchProviders[itemPosition];
            return true;
        }
    }
}