using MyGameShopApi.Entities;
using System.Collections.Generic;
using System;

namespace MyGameShopApi.Models
{
    public class ReceiptDto
    {
        public int Id { get; set; }
        public decimal TotalPrice { get; set; }
        public DateTime Date { get; set; }
        public bool IsInvoiceIssued { get; set; }
        public string PaymentMethod { get; set; }
        public List<ProductDto> Products { get; set; }
    }
}
