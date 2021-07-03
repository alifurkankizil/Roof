using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthGuard.Models
{
    public class LoginRequestDTO
    {
        public string ClientId { get; set; }
        public string ClientSecret { get; set; }
        public string Scope { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
