using System.Collections.Generic;

namespace MvxSample.Core.Models.DuckDuckGo
{
    public class DuckDuckGoIcon
    {
        public string URL { get; set; }
        public object Height { get; set; }
        public object Width { get; set; }
    }

    public class DuckDuckGoRelatedTopic
    {
        public string Result { get; set; }
        public DuckDuckGoIcon DuckDuckGoIcon { get; set; }
        public string FirstURL { get; set; }
        public string Text { get; set; }
    }

    public class DuckDuckGoResult
    {
        public string DefinitionSource { get; set; }
        public string Heading { get; set; }
        public int ImageWidth { get; set; }
        public List<DuckDuckGoRelatedTopic> RelatedTopics { get; set; }
        public string Entity { get; set; }
        public string Type { get; set; }
        public string Redirect { get; set; }
        public string DefinitionURL { get; set; }
        public string AbstractURL { get; set; }
        public string Definition { get; set; }
        public string AbstractSource { get; set; }
        public string Infobox { get; set; }
        public string Image { get; set; }
        public int ImageIsLogo { get; set; }
        public string Abstract { get; set; }
        public string AbstractText { get; set; }
        public string AnswerType { get; set; }
        public int ImageHeight { get; set; }
        public List<DuckDuckGoRelatedTopic> Results { get; set; }
        public string Answer { get; set; }
    }
}
