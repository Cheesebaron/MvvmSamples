using System.Collections.Generic;
using System.Threading.Tasks;
using MvxSample.Core.Models;

namespace MvvmLightSample.Core.Services
{
    public interface ISearchProvider
    {
        Task<IEnumerable<SearchResult>> QueryAsync(string query);
    }
}
