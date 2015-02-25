using Cirrious.MvvmCross.ViewModels;

namespace MvxSample.Core.ViewModels
{
    public class SearchDetailViewModel : MvxViewModel
    {
        private string _url;

        public void Init(string url)
        {
            Url = url;
        }

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
