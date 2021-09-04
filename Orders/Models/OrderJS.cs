using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Orders.Models
{
    public class OrderJS
    {
        public string ApiVersion { get; set; }
        public Order[] Result { get; set; }
        public int ResponseCode { get; set; }
    }
}