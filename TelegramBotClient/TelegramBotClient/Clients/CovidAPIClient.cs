using ApiBotTelegram.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace TelegramBotClient.Clients
{
    public static class CovidAPIClient
    {
        public static HttpClient ApiClient { get; set; }
        public static string BaseURL = $"http://localhost:57715/api/CountrySituation/";
        
        public static async Task<List<CountrySituation>> GetCountrySituation(string CountryName)
        {
            ApiClient = new HttpClient();
            ApiClient.DefaultRequestHeaders.Accept.Clear();
            ApiClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            string url = BaseURL+$"{CountryName}";

            using (HttpResponseMessage response = await ApiClient.GetAsync(url))
            {
                if (response.IsSuccessStatusCode)
                {
                    List<CountrySituation> _countrySituation = await response.Content.ReadAsAsync<List<CountrySituation>>();
                    return _countrySituation;                                        
                }
                else
                    throw new Exception(response.ReasonPhrase);
            }
        }
    }
}
