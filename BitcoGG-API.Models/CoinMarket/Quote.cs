using System.ComponentModel.DataAnnotations.Schema;

namespace BitcoGG_API.Models
{
    [NotMapped]
    public class Quote
    {
        public Usd USD { get; set; }
    }
}