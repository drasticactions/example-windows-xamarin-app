using example_windows_app.Tools.Common;
using example_windows_app.Tools.News;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Toolkit.Uwp;
using windows_central_client.Models.News;
using windows_central_client.Managers;

namespace example_windows_app.ViewModels
{
    public class MainPageViewModel : NotifierBase
    {
        public MainPageViewModel()
        {
            FeaturedArticles = new Featured[0];
        }
        public IncrementalLoadingCollection<NewsSource, Article> NewsSource { get; set; } = new IncrementalLoadingCollection<NewsSource, Article>();

        private Featured[] _featuredArticles;
        public Featured[] FeaturedArticles
        {
            get { return _featuredArticles; }
            set
            {
                SetProperty(ref _featuredArticles, value);
                OnPropertyChanged();
            }
        }

        public async Task GetFeaturedArticles()
        {
            var result = await NewsManager.GetNewsResult();
            FeaturedArticles = result.Featured;
        }
    }
}
