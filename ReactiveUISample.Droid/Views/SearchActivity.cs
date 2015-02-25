using System.Collections.Generic;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Views;
using Android.Widget;
using ReactiveUI;
using ReactiveUISample.Core.Services;
using ReactiveUISample.Core.ViewModels;

namespace ReactiveUISample.Droid.Views
{
    [Activity(Label = "ReactiveUI Sample", MainLauncher = true, Icon = "@drawable/icon")]
    public class SearchActivity : ReactiveActivity<SearchViewModel>, ActionBar.IOnNavigationListener
    {
        public EditText SearchText { get; private set; }
        public Button SearchButton { get; private set; }
        public ListView SearchResultListView { get; private set; }

        private readonly IList<SearchProvider> _searchProviders = new[] {SearchProvider.DuckDuckGo, SearchProvider.Searx};

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);
            ViewModel = new SearchViewModel();

            ActionBar.NavigationMode = ActionBarNavigationMode.List;

            var spinnerAdapter = new ArrayAdapter<SearchProvider>(this, Android.Resource.Layout.SimpleSpinnerItem,
                _searchProviders);

            ActionBar.SetListNavigationCallbacks(spinnerAdapter, this);
            ActionBar.SetSelectedNavigationItem(0);

            SearchText = FindViewById<EditText>(Resource.Id.queryEditText);
            SearchButton = FindViewById<Button>(Resource.Id.searchButton);
            SearchResultListView = FindViewById<ListView>(Resource.Id.searchResultsListView);

            this.Bind(ViewModel, vm => vm.SearchQuery, v => v.SearchText.Text);
            this.BindCommand(ViewModel, vm => vm.Search, v => v.SearchButton);

            var adapter = new ReactiveListAdapter<SearchResultViewModel>(
                ViewModel.SearchResults,
                (viewModel, parent) => new SearchResultItemView(viewModel, this, parent));
            SearchResultListView.Adapter = adapter;
        }

        public bool OnNavigationItemSelected(int itemPosition, long itemId)
        {
            ViewModel.SearchProvider = _searchProviders[itemPosition];
            return true;
        }
    }

    public class SearchResultItemView : ReactiveViewHost<SearchResultViewModel>
    {
        public SearchResultItemView(SearchResultViewModel viewModel, Context ctx, ViewGroup parent)
			: base(ctx, Resource.Layout.SearchResultListItem, parent)
		{
			ViewModel = viewModel;

			this.OneWayBind(ViewModel, vm => vm.Title, v => v.Title.Text);
            this.OneWayBind(ViewModel, vm => vm.Content, v => v.Content.Text);
		}

		public TextView Title { get; private set; }
        public TextView Content { get; private set; }
    }
}

