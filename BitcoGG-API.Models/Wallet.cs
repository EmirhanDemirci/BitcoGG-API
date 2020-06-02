using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BitcoGG_API.Models
{
    public class Wallet
    {
        public int WalletId { get; set; }
        public int CoinId { get; set; }
        public User UserId { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Amount { get; set; }
        public int TotalValue { get; set; }
    }
}
