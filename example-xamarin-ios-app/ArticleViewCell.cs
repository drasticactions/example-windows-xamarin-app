using Foundation;
using System;
using FFImageLoading;
using FFImageLoading.Transformations;
using UIKit;
using windows_central_client.Models.News;

namespace example_xamarin_ios_app
{
    public partial class ArticleViewCell : UITableViewCell
    {
        public ArticleViewCell (IntPtr handle) : base (handle)
        {
        }

        public void Update(Article article)
        {
            ImageService.Instance
                        .LoadUrl(article.FirstImage)
                        .Transform(new RoundedTransformation(15))
                        .Into(ArticleImage);

            ArticleBadge.Text = article.BadgeUpper;
            Title.Text = article.Title;
            Title.SizeToFit();
        }
    }
}