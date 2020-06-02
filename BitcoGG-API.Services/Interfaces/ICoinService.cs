using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using BitcoGG_API.Models;
using BitcoGG_API.Models.CoinsNews;

namespace BitcoGG_API.Services.Interfaces
{
    public interface ICoinService
    {
        Task<RootObject> GetCoins();
        Task<RootObject> GetSpecificCoin(int id);
        Task<CoinsNews> GetNews();
    }
}
