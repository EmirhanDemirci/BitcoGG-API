using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BitcoGG_API.Models
{
    public class Wallet
    {
        public int WalletId { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public string TotalValue { get; set; }
        public List<Coin> Coins { get; set; }
    }
}
