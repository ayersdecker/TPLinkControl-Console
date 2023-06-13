using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace TPLinkControl
{
    public class ApiRequest
    {
        public async Task<dynamic> ResponseDynamic(string url, string un, string pw)
        {
            var body = 
            // Builds Request
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0 (platform; rv:geckoversion) Gecko/geckotrail Firefox/firefoxversion");
            client.DefaultRequestHeaders.Add()
            HttpResponseMessage response = await client.GetAsync(url);
            response.EnsureSuccessStatusCode();

            // Get JSON Data
            string content = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<dynamic>(content);
        }
    }
}
