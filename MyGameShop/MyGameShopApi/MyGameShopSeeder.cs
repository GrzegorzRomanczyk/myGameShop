using MyGameShopApi.Entities;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace MyGameShopApi
{
    public class MyGameShopSeeder
    {
        private readonly MyGameShopDbContext dbContext;

        public MyGameShopSeeder(MyGameShopDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public void Seed()
        {
            if(dbContext.Database.CanConnect())
            {
                if (!dbContext.Pegis.Any())
                {
                    var pegi = GetPegi();
                    dbContext.Pegis.AddRange(pegi);
                    dbContext.SaveChanges();
                }

                if (!dbContext.Products.Any())
                {
                    var products = GetProducts();
                    dbContext.Products.AddRange(products);
                    dbContext.SaveChanges();
                }
            }
        }

        private static IEnumerable<Pegi> GetPegi()
        {
            var pegi = new List<Pegi>()
            {
                new Pegi()
                {
                    AgeCategory = "16"
                }
            };
            return pegi;
        }

        private static IEnumerable<Product> GetProducts()
        {
            var products = new List<Product>()
            {
                new Product()
                {
                    Name = "GTA 6",
                    StockCount = 69,
                    PriceBrutto = 299.99M,
                    PegiId = 1,
                }
            };

            return products;
        }
    }
}
