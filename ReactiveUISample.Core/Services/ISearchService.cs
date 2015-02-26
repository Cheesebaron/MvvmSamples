using System;
using ReactiveUISample.Core.ViewModels;

namespace ReactiveUISample.Core.Services
{
    public enum SearchProvider
    {
        Searx,
        DuckDuckGo
    }

    public interface ISearchService
    {
        IObservable<SearchResultViewModel> QueryAsync(string query, SearchProvider provider);
    }
}
