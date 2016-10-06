using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using windows_central_client.Models;

namespace windows_central_client.Managers
{
    public class NewsManager
    {
        public async Task<NewsResult> GetNewsResult()
        {
            using (var client = new HttpClient())
            {
                var result = await client.GetAsync("http://www.windowscentral.com/mobile_app/feed/json?limit=15&format=full&ticks=636113816691630509&page=0");
                var jsonString = await result.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<NewsResult>(jsonString);
            }
        }
    }
}
