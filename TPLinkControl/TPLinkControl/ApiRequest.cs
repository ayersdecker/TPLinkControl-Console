using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace TPLinkControl
{
    public class ApiRequest
    {
        public async Task<dynamic> LoginDynamic(string un, string pw)
        {
            


            var json = "{\n \"method\": \"login\",\n \"params\": {\n \"appType\": \"Kasa\",\n \"cloudUserName\": \"" + $"{un}" + "\",\n \"cloudPassword\": \"" + $"{pw}" + "\",\n \"terminalUUID\": \"4c840107-5353-4a7a-b46e-77dd1d72f526\"}"+"}";

            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Post,
                RequestUri = new Uri("https://wap.tplinkcloud.com"),
                Content = new StringContent(json, Encoding.UTF8, "application/json")
            };
            // Builds Request
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0 (platform; rv:geckoversion) Gecko/geckotrail Firefox/firefoxversion");
            request.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            var response = await client.SendAsync(request);
            response.EnsureSuccessStatusCode();

            // Get JSON Data
            string content = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<dynamic>(content);
        }
        public async Task<dynamic> ShowDevicesDynamic(string token)
        {
            var json = "{\n \"method\": \"getDeviceList\""+ "}";

            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Post,
                RequestUri = new Uri("https://wap.tplinkcloud.com?token=" + $"{token}"),
                Content = new StringContent(json, Encoding.UTF8, "application/json")
            };
            // Builds Request
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0 (platform; rv:geckoversion) Gecko/geckotrail Firefox/firefoxversion");
            request.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            var response = await client.SendAsync(request);
            response.EnsureSuccessStatusCode();

            // Get JSON Data
            string content = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<dynamic>(content);
        }
        public async Task<dynamic> TurnDevice(string token, string state, string deviceID, string color, string light)
        {
            var json = "{\n \"method\":\"passthrough\", \n \"params\": {\n \"deviceId\": \"" + $"{deviceID}" + "\", \n \"requestData\": {\"smartlife.iot.smartbulb.lightingservice\":{\"transition_light_state\":{\"on_off\":" + $"{state}" + ", \"brightness\":" + $"{light}" + ",\"hue\":" + $"{color}" + ",\"saturation\":100}" + "}} }}";

            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Post,
                RequestUri = new Uri("https://wap.tplinkcloud.com?token=" + $"{token}"),
                Content = new StringContent(json, Encoding.UTF8, "application/json")
            };
            // Builds Request
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0 (platform; rv:geckoversion) Gecko/geckotrail Firefox/firefoxversion");
            request.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            var response = await client.SendAsync(request);
            response.EnsureSuccessStatusCode();

            // Get JSON Data
            string content = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<dynamic>(content);
        }
    }
    
}
