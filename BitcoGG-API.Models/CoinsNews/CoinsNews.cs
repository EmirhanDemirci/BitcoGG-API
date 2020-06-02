using System;
using System.Collections.Generic;
using System.Text;

namespace BitcoGG_API.Models.CoinsNews
{
    public class CoinsNews
    {
        public string status { get; set; }
        public int totalResults { get; set; }
        public List<Article> articles { get; set; }
    }
}
