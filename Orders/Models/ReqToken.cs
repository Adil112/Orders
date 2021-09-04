using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Orders.Models
{
    public class ReqToken
    {
        public string RequestToken { get; set; }
        public string AccessToken { get; set; }
        int Expires { get; set; }
        string RefreshToken { get; set; }
        string Scope { get; set; }
        string Error { get; set; }
        bool Success { get; set; }
        bool RequireSsl { get; set; }
    }
}