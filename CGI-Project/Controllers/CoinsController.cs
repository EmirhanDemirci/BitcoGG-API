using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using BitcoGG_API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace BitcoGG_API.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class CoinsController : ControllerBase
    {
        private static string API_KEY = "e59bd4f0-b6d4-4750-a58c-7c4357a6534f";
        //private Coins _coins;
        //public CoinsController(Coins coins)
        //{
        //    _coins = coins;
        //}

       [HttpGet]
        public async Task<IActionResult> GetCoins()
        {
             Coins.RootObject reservationList = new Coins.RootObject();
            using (var httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Add("X-CMC_PRO_API_KEY", API_KEY);
                httpClient.DefaultRequestHeaders.Add("Accepts", "application/json");
                using (var response = await httpClient.GetAsync("https://pro-api.coinmarketcap.com/v1/cryptocurrency/listings/latest"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    reservationList = JsonConvert.DeserializeObject<Coins.RootObject>(apiResponse);
                }
                
            }
            return Ok(reservationList); 
        }
    }


}