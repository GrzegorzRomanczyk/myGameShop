using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MyGameShopApi.Entities;
using MyGameShopApi.Models;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Linq;

namespace MyGameShopApi.Services
{
    public class ProductService : IProductService
    {
        private readonly MyGameShopDbContext dbContext;
        private readonly IMapper mapper;

        public ProductService(MyGameShopDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }

        public ProductDto GetById(int id)
        {
            var product = dbContext.Products
                 .Include(r => r.Pegi)
                 .FirstOrDefault(r => r.Id == id);
            if (product is null)
            {
                return null;
            }
            var productDto = mapper.Map<ProductDto>(product);
            return productDto;
        }

        public IEnumerable<ProductDto> GetAll()
        {
            var products = dbContext.Products
                .Include(r => r.Pegi)
                .ToList();
            var productsDto = mapper.Map<List<ProductDto>>(products);
            return productsDto;
        }

        public int Create(CreateProductDto dto)
        {
            var product = mapper.Map<Product>(dto);
            dbContext.Products.Add(product);
            dbContext.SaveChanges();
            return product.Id;
        }

        public bool Delete(int id)
        {
            var product = dbContext.Products
                .FirstOrDefault(r => r.Id == id);
            if(product is null)
            {
                return false;
            }
            dbContext.Products.Remove(product);
            dbContext.SaveChanges();
            return true;
        }
    }
}
