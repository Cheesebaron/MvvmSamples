using System;
using System.Collections.Generic;
using System.Reactive.Linq;
using System.Threading.Tasks;
using MvxSample.Core.Models;
using ReactiveUISample.Core.ViewModels;

namespace ReactiveUISample.Core.Services
{
    public class SearchService : ISearchService
    {
        private readonly ISearchProvider _duckDuckGoProvider;
        private readonly ISearchProvider _searxProvider;

        public SearchService()
        {
            _duckDuckGoProvider = new DuckDuckGoInstantAnswerSearchProvider();
            _searxProvider = new SearxSearchProvider();
        }

        public IObservable<SearchResultViewModel> QueryAsync(string query, SearchProvider provider)
        {
            Task<IEnumerable<SearchResult>> resultTask;
            switch (provider)
            {
                case SearchProvider.DuckDuckGo:
                    resultTask = _duckDuckGoProvider.QueryAsync(query);
                    break;
                default:
                    resultTask = _searxProvider.QueryAsync(query);
                    break;
            }

            return Observable.Create<SearchResultViewModel>(async observer =>
            {
                try
                {
                    var results = await resultTask.ConfigureAwait(false);
                    foreach(var result in results)
                        observer.OnNext(new SearchResultViewModel(result));
                }
                catch (Exception e)
                {
                    observer.OnError(e);
                    return;
                }
                observer.OnCompleted();
            });
        }
    }
}
