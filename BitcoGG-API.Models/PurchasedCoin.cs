using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BitcoGG_API.Models
{
    public class PurchasedCoin
    {
        [Key]
        public int CoinId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public float Price { get; set; }
        [Required]
        public int Quantity { get; set; }
        [Required]
        public int TotalValue { get; set; }
        [Required]
        public int WalletId { get; set; }
        public Wallet Wallet { get; set; }
    }
}
