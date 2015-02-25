using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Cirrious.CrossCore.Platform;
using ModernHttpClient;
using MvxSample.Core.Models;
using MvxSample.Core.Models.DuckDuckGo;

namespace MvxSample.Core.Services
{
    public class DuckDuckGoInstantAnswerSearchProvider : ISearchProvider
    {
        private readonly IMvxJsonConverter _jsonConverter;

        public DuckDuckGoInstantAnswerSearchProvider(IMvxJsonConverter jsonConverter)
        {
            _jsonConverter = jsonConverter;
        }

        private const string DuckDuckGoQueryUrl = "http://api.duckduckgo.com/?format=json&q=";

        public async Task<IEnumerable<SearchResult>> QueryAsync(string query)
        {
            var url = DuckDuckGoQueryUrl + WebUtility.UrlEncode(query);
            var client = new HttpClient(new NativeMessageHandler());
            var json = await client.GetStringAsync(url).ConfigureAwait(false);

            var results = _jsonConverter.DeserializeObject<DuckDuckGoResult>(json);
            var result = new List<SearchResult>();
            var first = results.Results.FirstOrDefault();
            if (first != null)
                result.Add(new SearchResult
                {
                    Url = first.FirstURL,
                    Title = first.Text,
                    Content = first.Result
                });
            result.AddRange(results.RelatedTopics.Select(related => new SearchResult
            {
                Url = related.FirstURL, Title = related.Text, Content = related.Result
            }));

            return result;
        }
    }
}
