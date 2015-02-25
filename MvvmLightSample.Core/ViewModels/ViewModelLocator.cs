using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;
using Microsoft.Practices.ServiceLocation;
using MvvmLightSample.Core.Services;

namespace MvvmLightSample.Core.ViewModels
{
    public class ViewModelLocator
    {
        public const string DetailsPageKey = "SearchDetailPage";

        public SearchViewModel Main
        {
            get
            {
                return ServiceLocator.Current.GetInstance<SearchViewModel>();
            }
        }

        static ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);
            SimpleIoc.Default.Register<ISearchService, SearchService>();
            SimpleIoc.Default.Register<SearchViewModel>();
        }
    }
}
