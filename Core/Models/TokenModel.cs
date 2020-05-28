using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Models
{
    public class TokenModel
    {
        public string Token { get; set; }
        public DateTime Expiration { get; set; }
    }
}
