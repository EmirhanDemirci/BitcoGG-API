using System.Collections.Generic;
using System.Text;

namespace BitcoGG_API.Models
{
    public class RootObject
    {
        public Status status { get; set; }
        public List<Coin> data { get; set; }
    }
}
