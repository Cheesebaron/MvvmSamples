using GalaSoft.MvvmLight;
using MvxSample.Core.Models;

namespace MvvmLightSample.Core.ViewModels
{
    public class SearchDetailViewModel : ViewModelBase
    {
        public SearchDetailViewModel(SearchResult model)
        {
            _url = model.Url;
        }

        private string _url;
        public string Url
        {
            get { return _url; }
            set
            {
                _url = value;
                RaisePropertyChanged(() => Url);
            }
        }
    }
}
