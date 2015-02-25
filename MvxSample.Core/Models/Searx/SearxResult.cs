using System.Collections.Generic;

namespace MvxSample.Core.Models.Searx
{
    public class SearxResult
    {
        public string engine { get; set; }
        public List<string> engines { get; set; }
        public string title { get; set; }
        public string url { get; set; }
        public List<string> parsed_url { get; set; }
        public string content { get; set; }
        public string pretty_url { get; set; }
        public string host { get; set; }
        public double score { get; set; }
    }
}
