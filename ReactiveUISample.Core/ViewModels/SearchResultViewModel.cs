using MvxSample.Core.Models;
using ReactiveUI;
using Splat;

namespace ReactiveUISample.Core.ViewModels
{
    public class SearchResultViewModel : ReactiveObject
    {
        public string Title { get; protected set; }
        public string Content { get; protected set; }
        public ReactiveCommand<object> ShowThisResult { get; protected set; }

        public SearchResultViewModel(SearchResult model, IScreen hostScreen = null)
        {
            hostScreen = hostScreen ?? Locator.Current.GetService<IScreen>();

            Title = model.Title;
            Content = model.Content;

            ShowThisResult = ReactiveCommand.CreateAsyncObservable(_ =>
                hostScreen.Router.Navigate.ExecuteAsync(new SearchDetailViewModel(model)));
        }
    }
}
