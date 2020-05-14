﻿using System.ComponentModel.DataAnnotations.Schema;

namespace BitcoGG_API.Models
{
    [NotMapped]
    public class Platform
    {
        public int id { get; set; }
        public string name { get; set; }
        public string symbol { get; set; }
        public string slug { get; set; }
        public string token_address { get; set; }
    }
}