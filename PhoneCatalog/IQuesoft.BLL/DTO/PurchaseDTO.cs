
using System;

namespace IQuesoftTask.Bll.DTO
{
    public class PurchaseDto
    {
        public int Id { get; set; }
        public DateTime PurchaseDate { get; set; }
        public int? SellerId { get; set; }
        public SellerDto Seller { get; set; }
    }
}