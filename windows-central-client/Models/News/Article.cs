using Newtonsoft.Json;
using System.Linq;

namespace windows_central_client.Models.News
{

    public class Article
    {

        [JsonProperty("nid")]
        public string Nid { get; set; }

        [JsonProperty("permaLink")]
        public string PermaLink { get; set; }

        [JsonProperty("internalLink")]
        public string InternalLink { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("author")]
        public string Author { get; set; }

        [JsonProperty("pp_uid")]
        public string PpUid { get; set; }

        [JsonProperty("published_date")]
        public string PublishedDate { get; set; }

        [JsonProperty("modified_date")]
        public string ModifiedDate { get; set; }

        [JsonProperty("sticky")]
        public string Sticky { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("comment_mode")]
        public string CommentMode { get; set; }

        [JsonProperty("short_title")]
        public string ShortTitle { get; set; }

        [JsonProperty("badge")]
        public string Badge { get; set; }

        public string BadgeUpper
        {
            get
            {
                return Badge?.ToUpper();
            }
        }

        [JsonProperty("categories")]
        public string[] Categories { get; set; }

        [JsonProperty("tags")]
        public string[] Tags { get; set; }

        [JsonProperty("section")]
        public string[] Section { get; set; }

        [JsonProperty("featured_background")]
        public bool FeaturedBackground { get; set; }

        [JsonProperty("visor_article")]
        public bool VisorArticle { get; set; }

        [JsonProperty("images")]
        public string[] Images { get; set; }

        public string FirstImage { get
            {
                return Images.FirstOrDefault();
            }
        }

        [JsonProperty("tinted_image")]
        public string TintedImage { get; set; }

        [JsonProperty("content")]
        public string Content { get; set; }

        [JsonProperty("comment_count")]
        public string CommentCount { get; set; }

        [JsonProperty("topics")]
        public string[] Topics { get; set; }

        [JsonProperty("featured_image")]
        public bool? FeaturedImage { get; set; }

        [JsonProperty("visor_best")]
        public bool? VisorBest { get; set; }

        [JsonProperty("visor_review")]
        public bool? VisorReview { get; set; }

        [JsonProperty("summary")]
        public string Summary { get; set; }
    }

}
