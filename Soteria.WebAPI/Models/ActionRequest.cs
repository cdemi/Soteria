using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Soteria.WebAPI.Models
{
    public class ActionRequest
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string UserAgent { get; set; }
        public string IP { get; set; }
    }
}
