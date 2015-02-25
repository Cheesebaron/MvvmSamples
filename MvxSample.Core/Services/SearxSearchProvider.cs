using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Cirrious.CrossCore.Platform;
using ModernHttpClient;
using MvxSample.Core.Models;
using MvxSample.Core.Models.Searx;

namespace MvxSample.Core.Services
{
    public class SearxSearchProvider : ISearchProvider
    {
        private readonly IMvxJsonConverter _jsonConverter;

        public SearxSearchProvider(IMvxJsonConverter jsonConverter)
        {
            _jsonConverter = jsonConverter;
        }

        private const string SearxQueryUrl = "http://searx.me/?format=json&q=";

        public async Task<IEnumerable<SearchResult>> QueryAsync(string query)
        {
            var url = SearxQueryUrl + WebUtility.UrlEncode(query);
            var handler = new NativeMessageHandler(false, true);
            var client = new HttpClient(handler);
            var json = await client.GetStringAsync(url).ConfigureAwait(false);

            var results = _jsonConverter.DeserializeObject<SearxResultCollection>(json);

            return results.results.Select(res => new SearchResult
            {
                Url = res.url, Title = res.title, Content = res.content
            });
        }
    }
}
