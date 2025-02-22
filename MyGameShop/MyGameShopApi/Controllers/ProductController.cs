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
            var isDeleted = productService.Delete(id);
            if(isDeleted)
            {
                return NoContent();
            }
            return NotFound();
        }

        [HttpPost]
        public ActionResult CreateProduct([FromBody]CreateProductDto dto)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
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
            if(product is null)
            {
                return NotFound();
            }
            return Ok(product);
        }
    }
}
