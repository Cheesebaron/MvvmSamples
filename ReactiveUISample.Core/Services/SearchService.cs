using System.Collections.Generic;
using System.Threading.Tasks;
using MvxSample.Core.Models;

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

        public Task<IEnumerable<SearchResult>> QueryAsync(string query, SearchProvider provider)
        {
            switch (provider)
            {
                case SearchProvider.DuckDuckGo:
                    return _duckDuckGoProvider.QueryAsync(query);
                case SearchProvider.Searx:
                    return _searxProvider.QueryAsync(query);
            }
            return null;
        }
    }
}
