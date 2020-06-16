using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BitcoGG_API.Models
{
    public class Wallet
    {
        [Key]
        public int WalletId { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public string Name { get; set; }
    }
}
