using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using BitcoGG_API.Models;
using BitcoGG_API.Models.CoinsNews;
using Newtonsoft.Json;

namespace BitcoGG_API.DataAccess.Data
{
    public class CoinMarketApi
    {
        //TODO: Change hardcoded KEY;
        private static string API_KEY = "e59bd4f0-b6d4-4750-a58c-7c4357a6534f";

        public async Task<RootObject> GetCoins()
        {
            RootObject reservationList = new RootObject();
            using (var httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Add("X-CMC_PRO_API_KEY", API_KEY);
                httpClient.DefaultRequestHeaders.Add("Accepts", "application/json");
                using (var response =
                    await httpClient.GetAsync("https://pro-api.coinmarketcap.com/v1/cryptocurrency/listings/latest"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    reservationList = JsonConvert.DeserializeObject<RootObject>(apiResponse);
                }
            }

            return reservationList;
        }

        public async Task<RootObject> GetSpecificCoin(int id)
        {
            var URL = new UriBuilder("https://pro-api.coinmarketcap.com/v1/cryptocurrency/listings/latest");
            RootObject specificCoin = new RootObject();
            using (var httpClient = new HttpClient())
            {
                var queryString = HttpUtility.ParseQueryString(string.Empty);
                queryString["start"] = id.ToString();
                queryString["limit"] = "1";
                URL.Query = queryString.ToString();
                httpClient.DefaultRequestHeaders.Add("X-CMC_PRO_API_KEY", API_KEY);
                httpClient.DefaultRequestHeaders.Add("Accepts", "application/json");
                using (var response = await httpClient.GetAsync(URL.ToString()))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    specificCoin = JsonConvert.DeserializeObject<RootObject>(apiResponse);
                }
            }

            return specificCoin;
        }

        public async Task<CoinsNews> GetNews()
        {
            CoinsNews GetCoinsNews = new CoinsNews();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync(
                    "https://newsapi.org/v2/top-headlines?country=us&apiKey=4bd0853c5d79424fbe9d065ae4780973"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    GetCoinsNews = JsonConvert.DeserializeObject<CoinsNews>(apiResponse);
                }
                return GetCoinsNews;
            }
        }
    }
}
