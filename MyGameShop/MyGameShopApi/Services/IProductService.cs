using MyGameShopApi.Models;
using System.Collections.Generic;

namespace MyGameShopApi.Services
{
    public interface IProductService
    {
        int Create(CreateProductDto dto);
        IEnumerable<ProductDto> GetAll();
        ProductDto GetById(int id);
        bool Delete(int id);
    }
}