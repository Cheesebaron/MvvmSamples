using System.Collections.Generic;
using System.Threading.Tasks;
using MvxSample.Core.Models;

namespace MvxSample.Core.Services
{
    public interface ISearchProvider
    {
        Task<IEnumerable<SearchResult>> QueryAsync(string query);
    }
}
