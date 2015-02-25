using System.Collections.Generic;

namespace MvxSample.Core.Models.Searx
{
    public class SearxResultCollection
    {
        public string query { get; set; }
        public List<SearxResult> results { get; set; }
    }
}
