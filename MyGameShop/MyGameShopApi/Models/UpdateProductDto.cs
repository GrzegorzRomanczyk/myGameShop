using System.ComponentModel.DataAnnotations;

namespace MyGameShopApi.Models
{
    public class UpdateProductDto
    {
        [Required] // poki co tylko tutaj.. trzeba dodac tez w inne miejsce
        public decimal PriceBrutto { get; set; }
        public int StockCount { get; set; }
    }
}
