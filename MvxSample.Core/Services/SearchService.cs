using System.Collections.Generic;
using System.Threading.Tasks;
using Cirrious.CrossCore.Platform;
using MvxSample.Core.Models;

namespace MvxSample.Core.Services
{
    public class SearchService : ISearchService
    {
        private readonly ISearchProvider _duckDuckGoProvider;
        private readonly ISearchProvider _searxProvider;

        public SearchService(IMvxJsonConverter jsonConverter)
        {
            _duckDuckGoProvider = new DuckDuckGoInstantAnswerSearchProvider(jsonConverter);
            _searxProvider = new SearxSearchProvider(jsonConverter);
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
