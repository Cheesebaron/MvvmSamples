using System;
using Android.App;
using Android.Runtime;
using ReactiveUISample.Core.Services;
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

            Locator.CurrentMutable.RegisterConstant(new SearchService(), typeof(ISearchService));
        }
    }
}