using System;
using Android.App;
using Android.Runtime;
using ReactiveUI;
using ReactiveUISample.Core.Services;
using ReactiveUISample.Core.ViewModels;
using ReactiveUISample.Droid.Views;
using Splat;

namespace ReactiveUISample.Droid
{
    [Application(Label = "ReactiveUI Sample")]
    public class App : Application
    {
        public App(IntPtr herp, JniHandleOwnership derp) 
            : base(herp, derp) { }

        public override void OnCreate()
        {
            base.OnCreate();

            var resolver = Locator.CurrentMutable;
            resolver.RegisterConstant(new SearchService(), typeof(ISearchService));
            resolver.Register(() => new SearchDetailActivity(), typeof(IViewFor<SearchDetailViewModel>));
        }
    }
}