using MvxSample.Core.Models;
using ReactiveUI;
using Splat;

namespace ReactiveUISample.Core.ViewModels
{
    public class SearchDetailViewModel : ReactiveObject, IRoutableViewModel
    {
        private string _url;
        public string UrlPathSegment { get { return "Detail"; }}
        public IScreen HostScreen { get; private set; }

        public string Url
        {
            get { return _url; }
            set { this.RaiseAndSetIfChanged(ref _url, value); }
        }

        public SearchDetailViewModel(SearchResult result)
        {
            HostScreen = Locator.Current.GetService<IScreen>();

            Url = result.Url;
        }
    }
}
