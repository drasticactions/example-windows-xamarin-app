namespace example_windows_app.ViewModels
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Bezysoftware.Navigation;
    using Bezysoftware.Navigation.Activation;
    using Bezysoftware.Navigation.StatePersistence;
    using example_web_template;
    using GalaSoft.MvvmLight;
    using windows_central_client.Models.News;

    public class ArticlePageViewModel : ViewModelBase, IActivate<Article>
    {
        private Article item;

        public Article Item
        {
            get { return this.item; }
            private set { this.Set(() => this.Item, ref this.item, value); }
        }

        private string html;

        public string Html
        {
            get { return this.html; }
            private set { this.Set(() => this.Html, ref this.html, value); }
        }

        public Article State => this.Item;

        public async void Activate(NavigationType navigationType, Article data)
        {
            this.Item = data;
            this.LoadHtml(this.Item);
        }

        private void LoadHtml(Article article)
        {
            var newsTemplateModel = new NewsTemplateModel()
            {
                Article = article,
                Platform = AppPlatform.Windows
            };
            var newsTemplate = new NewsTemplate() { Model = newsTemplateModel };
            this.Html = newsTemplate.GenerateString();
        }
    }
}
