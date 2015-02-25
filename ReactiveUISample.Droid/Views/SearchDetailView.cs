using Android.App;
using Android.OS;
using Android.Webkit;
using ReactiveUI;
using ReactiveUISample.Core.ViewModels;

namespace ReactiveUISample.Droid.Views
{
    [Activity(Label = "Detail")]
    public class SearchDetailActivity : ReactiveActivity<SearchDetailViewModel>
    {
        public WebView WebView { get; private set; }

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.SearchDetailView);

            WebView = FindViewById<WebView>(Resource.Id.web);
            WebView.SetWebViewClient(new WebViewClient());
            WebView.Settings.JavaScriptEnabled = true;
        }
    }
}