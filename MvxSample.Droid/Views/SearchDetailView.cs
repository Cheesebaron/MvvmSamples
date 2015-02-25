using System;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Webkit;
using Cirrious.MvvmCross.Droid.Views;

namespace MvxSample.Droid.Views
{
    [Activity(Label = "Detail")]
    public class SearchDetailView : MvxActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.SearchDetailView);
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