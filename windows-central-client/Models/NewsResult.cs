using Newtonsoft.Json;
using windows_central_client.Models.News;

namespace windows_central_client.Models
{

    public class NewsResult
    {

        [JsonProperty("code")]
        public int Code { get; set; }

        [JsonProperty("msg")]
        public string Msg { get; set; }

        [JsonProperty("version")]
        public int Version { get; set; }

        [JsonProperty("timestamp")]
        public int Timestamp { get; set; }

        [JsonProperty("articles")]
        public Article[] Articles { get; set; }

        [JsonProperty("featured")]
        public Article[] Featured { get; set; }
    }

}
