using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Views;
using MvvmLightSample.Core.Services;
using MvxSample.Core.Models;

namespace MvvmLightSample.Core.ViewModels
{
    public class SearchViewModel : ViewModelBase
    {
        private readonly ISearchService _searchService;
        private readonly INavigationService _navigationService;
        private string _query = "What is cheese";
        private SearchProvider _selectedSearchProvider;
        private ObservableCollection<SearchResult> _searchResults;

        public SearchViewModel(ISearchService searchService, INavigationService navigationService)
        {
            _searchService = searchService;
            _navigationService = navigationService;
            SearchProviders = new[] { SearchProvider.DuckDuckGo, SearchProvider.Searx };
            SearchResults = new ObservableCollection<SearchResult>();
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

        public ObservableCollection<SearchResult> SearchResults
        {
            get { return _searchResults; }
            set
            {
                _searchResults = value;
                RaisePropertyChanged(() => SearchResults);
            }
        }

        public RelayCommand SearchCommand
        {
            get { return new RelayCommand(async () => await DoSearchCommand()); }
        }

        private async Task DoSearchCommand()
        {
            var results = await _searchService.QueryAsync(Query, SelectedSearchProvider);
            SearchResults.Clear();
            foreach(var result in results)
                SearchResults.Add(result);
        }

        public RelayCommand<SearchResult> ShowSearchResultCommand
        {
            get { return new RelayCommand<SearchResult>(DoShowSearchCommand); }
        }

        private void DoShowSearchCommand(SearchResult obj)
        {
            _navigationService.NavigateTo(ViewModelLocator.DetailsPageKey, obj);
        }
    }
}
