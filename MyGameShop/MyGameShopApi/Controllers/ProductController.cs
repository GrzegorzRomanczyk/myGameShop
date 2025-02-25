using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyGameShopApi.Entities;
using MyGameShopApi.Models;
using MyGameShopApi.Services;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace MyGameShopApi.Controllers
{
    [Route("api/product")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService productService;

        public ProductController(IProductService productService)
        {
            this.productService = productService;
        }

        [HttpDelete("{id}")]
        public ActionResult Delete([FromRoute] int id)
        {
            productService.Delete(id);
            return NotFound();
        }

        [HttpPut("{id}")]
        public ActionResult Update([FromRoute] int id, [FromBody] UpdateProductDto dto)
        {
            productService.Update(id, dto);
            return Ok();
        }

        [HttpPost]
        public ActionResult CreateProduct([FromBody]CreateProductDto dto)
        {
            var id = productService.Create(dto);
            return Created($"/api/product/{id}", null);
        }

        [HttpGet]
        public ActionResult<IEnumerable<ProductDto>> GetAllProducts() 
        {
            var productsDto = productService.GetAll();
            return Ok(productsDto);
        }

        [HttpGet("{id}")]
        public ActionResult<ProductDto> GetProduct([FromRoute] int id)
        {
            var product = productService.GetById(id);
            return Ok(product);
        }
    }
}
