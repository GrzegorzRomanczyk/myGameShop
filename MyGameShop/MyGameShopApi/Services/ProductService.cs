using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using MyGameShopApi.Entities;
using MyGameShopApi.Exceptions;
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
        private readonly ILogger<ProductService> logger;

        public ProductService(MyGameShopDbContext dbContext, IMapper mapper, ILogger<ProductService> logger)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
            this.logger = logger;
        }

        public void Update(int id, UpdateProductDto dto)
        {
            var product = dbContext.Products
                .FirstOrDefault(r => r.Id == id);
            if(product is null)
            {
                throw new NotFoundException("Product not found");
            }
            product.PriceBrutto = dto.PriceBrutto;
            product.StockCount = dto.StockCount;
            dbContext.SaveChanges();
        }

        public ProductDto GetById(int id)
        {
            var product = dbContext.Products
                 .Include(r => r.Pegi)
                 .FirstOrDefault(r => r.Id == id);
            if (product is null)
            {
                throw new NotFoundException("Product not found");
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

        public void Delete(int id)
        {
            logger.LogError($"Produckt with id: {id} DELETE action invoked");
            var product = dbContext.Products
                .FirstOrDefault(r => r.Id == id);
            if(product is null)
            {
                throw new NotFoundException("Product not found");
            }
            dbContext.Products.Remove(product);
            dbContext.SaveChanges();
        }
    }
}
