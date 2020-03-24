using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BitcoGG_API.Models
{
    public class Coins
    {
        public int id { get; set; }
        public string name { get; set; }
        public string symbol { get; set; }
        public int num_market_pairs { get; set; }
    }
}