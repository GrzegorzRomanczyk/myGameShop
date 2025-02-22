using MyGameShopApi.Entities;
using System.Collections.Generic;

namespace MyGameShopApi.Models
{
    public class ProductDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal PriceBrutto { get; set; }
        public int StockCount { get; set; }
        public string Pegi { get; set; }
    }
}
