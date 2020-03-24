using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using BitcoGG_API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BitcoGG_API.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class CoinsController : ControllerBase
    {
        private static string API_KEY = "e59bd4f0-b6d4-4750-a58c-7c4357a6534f";
        private Coins _coins;
        public CoinsController(Coins coins)
        {
            _coins = coins;
        }

       [HttpGet]
        public Object GetCoins()
        {
            var URL = new UriBuilder("https://pro-api.coinmarketcap.com/v1/cryptocurrency/listings/latest");

            var queryString = HttpUtility.ParseQueryString(string.Empty);
            queryString["start"] = "1";
            queryString["limit"] = "5000";
            queryString["convert"] = "USD";

            URL.Query = queryString.ToString();

            var client = new WebClient();
            client.Headers.Add("X-CMC_PRO_API_KEY", API_KEY);
            client.Headers.Add("Accepts", "application/json");
            return client.DownloadString(URL.ToString());
        }
    }


}