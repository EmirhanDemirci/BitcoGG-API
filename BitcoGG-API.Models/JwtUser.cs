using System;
using System.Collections.Generic;
using System.Text;

namespace BitcoGG_API.Models
{
    public class JwtUser
    {
        public User User { get; set; }
        public string Token { get; set; }
    }
}
