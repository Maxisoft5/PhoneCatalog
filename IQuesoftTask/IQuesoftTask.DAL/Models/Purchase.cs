
using System;

namespace IQuesoftTask.DAL.Models
{
    public class Purchase
    {
        public int Id { get; set; }
        public DateTime PurchaseDate { get; set; }
        public int? SellerId { get; set; }
        public Seller Seller { get; set; }
        public int? ProductId { get; set; }
        public Product Product { get; set; }
    }
}