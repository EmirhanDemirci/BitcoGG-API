using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using BitcoGG_API.DataAccess.Data;
using BitcoGG_API.Models;
using BitcoGG_API.Models.CoinsNews;
using BitcoGG_API.Services.Interfaces;

namespace BitcoGG_API.Services
{
    public class CoinService : ICoinService
    {
        private CoinMarketApi _coinMarket;

        public CoinService()
        {
            _coinMarket = new CoinMarketApi();
        }
        
        public async Task<RootObject> GetCoins()
        {
            //Get all the coins
            var coins =await _coinMarket.GetCoins();
            return coins;
        }
        public async Task<RootObject> GetSpecificCoin(int id)
        {
            //Get the specific coin
            var specificCoin = await _coinMarket.GetSpecificCoin(id);
            return specificCoin;
        }
        public async Task<CoinsNews> GetNews()
        {
            //Gets all the news
            var cryptoNews = await _coinMarket.GetNews();
            return cryptoNews;
        }
    }
}
