namespace example_windows_app.ViewModels
{
    using System.Collections.ObjectModel;
    using System.Threading.Tasks;
    using Bezysoftware.Navigation;
    using Bezysoftware.Navigation.Activation;
    using example_windows_app.Tools.News;
    using GalaSoft.MvvmLight;
    using Microsoft.Toolkit.Uwp;
    using windows_central_client.Managers;
    using windows_central_client.Models.News;

    public class MainPageViewModel : ViewModelBase, IActivate
    {
        public IncrementalLoadingCollection<NewsSource, Article> NewsSource { get; set; } = new IncrementalLoadingCollection<NewsSource, Article>();

        public ObservableCollection<Featured> FeaturedArticles { get; set; } = new ObservableCollection<Featured>();

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
