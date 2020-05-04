using System;
using System.Collections.Generic;

namespace BitcoGG_API.Models
{
    public class Coin
    {
        public int id { get; set; }
        public string name { get; set; }
        public string symbol { get; set; }
        public string slug { get; set; }
        public int num_market_pairs { get; set; }
        public DateTime date_added { get; set; }
        public List<object> tags { get; set; }
        public double? max_supply { get; set; }
        public double circulating_supply { get; set; }
        public double total_supply { get; set; }
        public Platform platform { get; set; }
        public int cmc_rank { get; set; }
        public DateTime last_updated { get; set; }
        public Quote quote { get; set; }
    }
}