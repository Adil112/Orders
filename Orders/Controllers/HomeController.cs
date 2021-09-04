using Newtonsoft.Json;
using Orders.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Web.Mvc;



namespace Orders.Controllers
{
    public class HomeController : Controller
    {
        
        public ActionResult Index()
        {
            API api = new API();
            List<string> ids = new List<string>();
            List<Order> orders = api.GetOrders();
            foreach (var t in orders)
            {
                ids.Add(t.Id);
            }
            return View(ids);
        }
        public ActionResult Index2(string id)
        {
            Order order = new Order();
            API api = new API();
            List<Order> orders = api.GetOrders();
            foreach (var t in orders)
            {
                if (t.Id == id) order = t;
            }
            return View(order);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}