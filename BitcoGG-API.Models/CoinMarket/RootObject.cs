using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BitcoGG_API.Models
{
    [NotMapped]
    public class RootObject
    {
        public Status status { get; set; }
        public List<Coin> data { get; set; }
    }
}
