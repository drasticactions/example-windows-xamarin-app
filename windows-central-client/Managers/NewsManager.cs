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
        public async static Task<NewsResult> GetNewsResult(int page = 0, int limit = 20)
        {
            using (var client = new HttpClient())
            {
                var result = await client.GetAsync($"http://www.windowscentral.com/mobile_app/feed/json?limit={limit}&format=full&ticks={new DateTime().Ticks}&page={page}");
                var jsonString = await result.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<NewsResult>(jsonString);
            }
        }
    }
}
