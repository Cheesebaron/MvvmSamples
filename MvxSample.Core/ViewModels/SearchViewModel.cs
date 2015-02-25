using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Cirrious.MvvmCross.ViewModels;
using MvxSample.Core.Models;
using MvxSample.Core.Services;

namespace MvxSample.Core.ViewModels
{
    public class SearchViewModel
        : MvxViewModel
    {
        private readonly ISearchService _searchService;
        private string _query = "What is cheese";
        private SearchProvider _selectedSearchProvider;
        private IList<SearchResult> _searchResults;

        public SearchViewModel(ISearchService searchService)
        {
            _searchService = searchService;
            SearchProviders = new[] {SearchProvider.DuckDuckGo, SearchProvider.Searx};
            SearchResults = new List<SearchResult>();
        }

        public string Query
        {
            get { return _query; }
            set
            {
                _query = value;
                RaisePropertyChanged(() => Query);
            }
        }

        public IList<SearchProvider> SearchProviders { get; set; }

        public SearchProvider SelectedSearchProvider
        {
            get { return _selectedSearchProvider; }
            set
            {
                _selectedSearchProvider = value;
                RaisePropertyChanged(() => SelectedSearchProvider);
            }
        }

        public IList<SearchResult> SearchResults
        {
            get { return _searchResults; }
            set
            {
                _searchResults = value;
                RaisePropertyChanged(() => SearchResults);
            }
        }

        public ICommand SearchCommand
        {
            get { return new MvxCommand(async () => await DoSearchCommand());}
        }

        private async Task DoSearchCommand()
        {
            var reults = await _searchService.QueryAsync(Query, SelectedSearchProvider);
            SearchResults = reults.ToList();
        }

        public ICommand ShowSearchResultCommand
        {
            get { return new MvxCommand<SearchResult>(DoShowSearchCommand);}
        }

        private void DoShowSearchCommand(SearchResult obj)
        {
            ShowViewModel<SearchDetailViewModel>(new {url = obj.Url});
        }
    }
}
