using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace BlogApril2017
{
    public class APIHandlerAsync
    {
        private const string  OPENWEATERMAP_URL = "http://api.openweathermap.org/data/2.5/weather?q={0}&APPID={1}&units={2}&mode=json";
        private static readonly string API_KEY = ConfigurationManager.AppSettings["openWeatherMapAPIKey"];

        public static async Task<OpenWeatherMapModel.Root> GetWeatherAsync(string city = "Zurich", string units = "metric")
        {
            using (var wc = new WebClient())
            {
                var json = await wc.DownloadStringTaskAsync(String.Format(OPENWEATERMAP_URL, city, 
                    API_KEY ?? throw new ArgumentNullException($"{nameof(API_KEY)} is null. Please enter a API Key in the App.config file"), units));
                return JsonConvert.DeserializeObject<OpenWeatherMapModel.Root>(json);
            }
        }
    }
}
