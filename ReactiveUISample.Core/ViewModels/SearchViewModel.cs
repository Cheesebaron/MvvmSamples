using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;
using MvxSample.Core.Models;
using ReactiveUI;
using ReactiveUISample.Core.Services;
using Splat;

namespace ReactiveUISample.Core.ViewModels
{
    public class SearchViewModel : ReactiveObject, IRoutableViewModel
    {
        private string _searchQuery;
        private SearchProvider _searchProvider;

        public ISearchService SearchService { get; protected set; }
        public string UrlPathSegment { get { return "Search Screen"; } }
        public IScreen HostScreen { get; protected set; }
        
        public string SearchQuery
        {
            get { return _searchQuery; }
            set { this.RaiseAndSetIfChanged(ref _searchQuery, value); }
        }

        public SearchProvider SearchProvider
        {
            get { return _searchProvider; }
            set { this.RaiseAndSetIfChanged(ref _searchProvider, value); }
        }

        public ReactiveCommand<IEnumerable<SearchResultViewModel>> Search { get; protected set; }

        public ReactiveList<SearchResultViewModel> SearchResults { get; set; }

        public SearchResult SelectedResult { get; set; }

        public ICommand GoToSearchDetailCommand { get; protected set; } 

        public SearchViewModel(IScreen hostScreen = null, ISearchService searchService = null)
        {
            HostScreen = hostScreen ?? Locator.Current.GetService<IScreen>();
            SearchService = searchService ?? Locator.Current.GetService<ISearchService>();

            Search = ReactiveCommand.CreateAsyncTask(this.WhenAny(x => x.SearchQuery,
                x => !string.IsNullOrWhiteSpace(x.Value)),
                async _ => (await searchService.QueryAsync(SearchQuery, SearchProvider))
                    .Select(x => new SearchResultViewModel(x)),
                RxApp.MainThreadScheduler);

            var gotoCmd = this.WhenAny(x => x.SelectedResult,
                change => change.Value != null).ToCommand(RxApp.MainThreadScheduler);
            gotoCmd.Subscribe(o => HostScreen.Router.Navigate.Execute(o));
            GoToSearchDetailCommand = gotoCmd;
        }
    }
}
