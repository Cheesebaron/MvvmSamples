using System;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Webkit;
using GalaSoft.MvvmLight.Helpers;
using MvvmLightSample.Core.ViewModels;
using MvxSample.Core.Models;

namespace MvvmLightSample.Droid.Views
{
    [Activity(Label = "Detail")]
    public class SearchDetailActivity : MvlActivity<SearchDetailViewModel>
    {
        private BindableWebView _webView;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.SearchDetailView);

            ViewModel = new SearchDetailViewModel(GlobalNavigation.GetAndRemoveParameter<SearchResult>(Intent));

            _webView = FindViewById<BindableWebView>(Resource.Id.web);

            // Why does this not work?!
            //this.SetBinding(() => ViewModel.Url, () => _webView.Source);

            _webView.Source = ViewModel.Url;
        }
    }

    public class BindableWebView : WebView
    {
        protected BindableWebView(IntPtr javaReference, JniHandleOwnership transfer)
            : base(javaReference, transfer) { }

        public BindableWebView(Context context)
            : this(context, null) { }

        public BindableWebView(Context context, IAttributeSet attrs)
            : this(context, attrs, 0) { }

        public BindableWebView(Context context, IAttributeSet attrs, int defStyleAttr)
            : base(context, attrs, defStyleAttr)
        {
            Init();
        }

        private void Init()
        {
            SetWebViewClient(new WebViewClient());
            Settings.JavaScriptEnabled = true;
        }

        private string _source;
        public string Source
        {
            get { return _source; }
            set
            {
                if (string.IsNullOrEmpty(value)) return;

                _source = value;

                LoadUrl(_source);
            }
        }
    }
}