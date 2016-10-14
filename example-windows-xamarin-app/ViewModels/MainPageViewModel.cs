namespace example_windows_app.ViewModels
{
    using System.Collections.ObjectModel;
    using System.Threading.Tasks;
    using Bezysoftware.Navigation;
    using Bezysoftware.Navigation.Activation;
    using example_windows_app.Tools.News;
    using GalaSoft.MvvmLight;
    using GalaSoft.MvvmLight.Command;
    using Microsoft.Toolkit.Uwp;
    using windows_central_client.Managers;
    using windows_central_client.Models.News;

    public class MainPageViewModel : ViewModelBase, IActivate
    {
        private readonly INavigationService nav;

        public MainPageViewModel(INavigationService nav)
        {
            this.nav = nav;
            this.NavigateCommand = new RelayCommand<Article>(g => this.nav.NavigateAsync<ArticlePageViewModel, Article>(g));
        }

        public RelayCommand<Article> NavigateCommand
        {
            get;
            private set;
        }

        public IncrementalLoadingCollection<NewsSource, Article> NewsSource { get; set; } = new IncrementalLoadingCollection<NewsSource, Article>();

        public ObservableCollection<Article> FeaturedArticles { get; set; } = new ObservableCollection<Article>();

        public async Task GetFeaturedArticles()
        {
            var result = await NewsManager.GetNewsResult();
            foreach (var item in result.Featured)
            {
                this.FeaturedArticles.Add(item);
            }
        }

        public async void Activate(NavigationType navigationType)
        {
            await this.GetFeaturedArticles();
        }
    }
}
