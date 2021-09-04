using Newtonsoft.Json;
using Orders.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace Orders
{
    public class API
    {
        public List<Order> GetOrders()
        {
            string reqUrl = "http://api.pixlpark.com/oauth/requesttoken";

            string username = "38cd79b5f2b2486d86f562e3c43034f8";
            string password = "8e49ff607b1f46e1a5e8f6ad5d312a80";

            HttpClient Client = new HttpClient();
            var mes = new HttpRequestMessage(HttpMethod.Get, reqUrl);
            HttpResponseMessage response = Client.SendAsync(mes).Result;
            var req = response.Content.ReadAsStringAsync();
            string reqTokenJson = req.Result;
            var reqToken = JsonConvert.DeserializeObject<ReqToken>(reqTokenJson);
            var reqTok = reqToken.RequestToken;

            var conc = reqTok + password;
            byte[] bytes = Encoding.ASCII.GetBytes(conc);
            SHA1 sha = new SHA1Managed();
            var hash = BitConverter.ToString(sha.ComputeHash(bytes)).Replace("-", ""); ;

            Console.WriteLine(1);

            string accUrl = "http://api.pixlpark.com/oauth/accesstoken?oauth_token=" + reqTok + "&grant_type=api&username=" + username + "&password=" + hash;
            var mes2 = new HttpRequestMessage(HttpMethod.Get, accUrl);
            HttpResponseMessage response2 = Client.SendAsync(mes2).Result;
            var acc = response2.Content.ReadAsStringAsync();
            var accTokenJson = acc.Result;
            var accToken = JsonConvert.DeserializeObject<ReqToken>(accTokenJson);
            var accTok = accToken.AccessToken;

            DateTime t1 = DateTime.UtcNow;
            var t2 = t1.AddDays(-10);
            var t11 = t1.ToString("s");
            var t22 = t2.ToString("s");
            var timeTo = t11.Substring(0, t11.Length - 3);
            var timeFrom = t22.Substring(0, t22.Length - 3);


            string orderUrl = "http://api.pixlpark.com/orders/betweenDates?oauth_token=" + accTok + "&datefrom=" + timeFrom + "&dateto=" + timeTo;
            var mes3 = new HttpRequestMessage(HttpMethod.Get, orderUrl);
            HttpResponseMessage response3 = Client.SendAsync(mes3).Result;
            var ordersJson = response3.Content.ReadAsStringAsync().Result;
            var order = JsonConvert.DeserializeObject<OrderJS>(ordersJson);

            List<Order> orders = new List<Order>();
            foreach (var t in order.Result)
            {
                orders.Add(t);
            }
            return orders;
        }
    }
}