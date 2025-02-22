using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MyGameShopApi.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal PriceBrutto { get; set; }
        public int StockCount { get; set; }
        public int PegiId { get; set; }
        public virtual Pegi Pegi { get; set; }
        public virtual List<Receipt> Receipts { get; set; }
    }
}
