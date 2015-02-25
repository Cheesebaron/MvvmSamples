using MvxSample.Core.Models;
using ReactiveUI;

namespace ReactiveUISample.Core.ViewModels
{
    public class SearchResultViewModel : ReactiveObject
    {
        public string Title { get; protected set; }
        public string Content { get; protected set; }

        public SearchResultViewModel(SearchResult model)
        {
            Title = model.Title;
            Content = model.Content;
        }
    }
}
