using System;
using System.Collections.Generic;

namespace MyGameShopApi.Entities
{
    public class Receipt
    {
        public int Id { get; set; }
        public decimal TotalPrice { get; set; }
        public int PaymentMethodId { get; set; }
        public DateTime Date { get; set; }
        public bool IsInvoiceIssued { get; set; }
        public virtual List<Product> Products { get; set; }
        public virtual PaymentMethod PaymentMethod { get; set; }
    }
}
