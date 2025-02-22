using System.ComponentModel.DataAnnotations;

namespace MyGameShopApi.Models
{
    public class CreateProductDto
    {
        [Required]
        [MaxLength(35)]
        public string Name { get; set; }
        public decimal PriceBrutto { get; set; }
        public int StockCount { get; set; }

        [Required]
        public int PegiId { get; set; }
    }
}
