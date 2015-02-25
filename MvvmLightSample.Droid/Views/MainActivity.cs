using Android.App;
using Android.Views;
using Android.Widget;
using Android.OS;
using GalaSoft.MvvmLight.Helpers;
using MvvmLightSample.Core.Services;
using MvvmLightSample.Core.ViewModels;
using MvvmLightSample.Droid.Views;
using MvxSample.Core.Models;

namespace MvvmLightSample.Droid
{
    [Activity(Label = "MvvmLight Sample", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : MvlActivity<SearchViewModel>, ActionBar.IOnNavigationListener
    {
        private Binding _saveBinding;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            ViewModel = App.Locator.Main;

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            ActionBar.NavigationMode = ActionBarNavigationMode.List;

            var adapter = new ArrayAdapter<SearchProvider>(this, Android.Resource.Layout.SimpleSpinnerItem,
                ViewModel.SearchProviders);

            ActionBar.SetListNavigationCallbacks(adapter, this);
            ActionBar.SetSelectedNavigationItem(0);

            var searchButton = FindViewById<Button>(Resource.Id.searchButton);
            var queryEdit = FindViewById<EditText>(Resource.Id.queryEditText);
            var resultsList = FindViewById<ListView>(Resource.Id.searchResultsListView);

            queryEdit.Text = ViewModel.Query;
            //_saveBinding = this.SetBinding(
            //    () => ViewModel.Query,
            //    () => queryEdit.Text);
            searchButton.SetCommand("Click", ViewModel.SearchCommand);

            resultsList.Adapter = ViewModel.SearchResults.GetAdapter(GetTemplateDelegate);
            resultsList.ItemClick +=
                (sender, args) =>
                {
                    ViewModel.ShowSearchResultCommand.Execute(ViewModel.SearchResults[args.Position]);
                };
        }

        private View GetTemplateDelegate(int position, SearchResult searchResult, View convertView)
        {
            convertView = LayoutInflater.Inflate(Resource.Layout.SearchResultListItem, null);

            var title = convertView.FindViewById<TextView>(Resource.Id.title);
            var content = convertView.FindViewById<TextView>(Resource.Id.content);

            title.Text = searchResult.Title;
            content.Text = searchResult.Content;

            return convertView;
        }

        public bool OnNavigationItemSelected(int itemPosition, long itemId)
        {
            ViewModel.SelectedSearchProvider = ViewModel.SearchProviders[itemPosition];
            return true;
        }
    }
}

