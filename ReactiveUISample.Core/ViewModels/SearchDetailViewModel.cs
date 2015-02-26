using MvxSample.Core.Models;
using ReactiveUI;

namespace ReactiveUISample.Core.ViewModels
{
    public class SearchDetailViewModel : ReactiveObject
    {
        private string _url;

        public string Url
        {
            get { return _url; }
            set { this.RaiseAndSetIfChanged(ref _url, value); }
        }

        public SearchDetailViewModel(SearchResult result)
        {
            Url = result.Url;
        }
    }
}
