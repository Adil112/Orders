using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Orders.Models
{
    public class Order
    {
        public string Id { get; set; }
        public string CustomId { get; set; }
        public string SourceOrderId { get; set; }
        public string Title { get; set; }
        public string TrackingUrl { get; set; }
        public string TrackingNumber { get; set; }
        public string Status { get; set; }
        public string RenderStatus { get; set; }
        public string PaymentStatus { get; set; }
        public Deliver DeliveryAddress { get; set; }
        public Ship Shipping { get; set; }
        public int CommentsCount { get; set; }
        public string DownloadLink { get; set; }
        public string PreviewImageUrl { get; set; }
        public double Price { get; set; }
        public double DiscountPrice { get; set; }
        public double DeliveryPrice { get; set; }
        public double TotalPrice { get; set; }
        public int UserId { get; set; }
        public object UserCompanyAccountId { get; set; }
        public int DiscountId { get; set; }
        public string DiscountTitle { get; set; }
        public string DateCreated { get; set; }
        public string DateModified { get; set; }
        public string DatePaid { get; set; }
    }
}