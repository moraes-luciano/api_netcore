using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Api_NetCore.Data;
using Api_NetCore.Filters;
using Api_NetCore.Models;
using Api_NetCore.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Api_NetCore.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IUnitOfWork _uof;

        public ProductsController(IUnitOfWork dbContext)
        {
            _uof = dbContext;
        }
        
        
        [HttpGet]
        [ServiceFilter(typeof(ApiLoggingFilter))]
        public ActionResult<IEnumerable<Product>> Get()
        {
            var products = _uof.ProductRepository.Get().ToList();
            
            if(products is null)
            {
                return NotFound();
            }
            return products;
        }

        [HttpGet("{id:int}", Name = "GetThisProduct")]
        public ActionResult<Product> Get(int id)
        {
            var product = _uof.ProductRepository.GetById(prod => prod.Id == id);
            
            if (product is null)
            {
                return NotFound();
            }
            return product;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Product>> GetProductsByPrice()
        {
            return _uof.ProductRepository.GetProductsByPrice().ToList();
        }
        [HttpPost]
        public ActionResult Post(Product product)
        {
            if (product is null)
            {
                return BadRequest();
            }
            
            _uof.ProductRepository.Add(product);
            _uof.Commit();
            return new CreatedAtRouteResult("GetThisProduct", new {id = product.Id}, product);
        }

        [HttpPut("{id:int}")]
        public ActionResult Put(int id, Product product)
        {
            if (id != product.Id)
            {
                return BadRequest();
            }

            _uof.ProductRepository.Update(product);
            _uof.Commit();

            return Ok(product);
        }

        [HttpDelete("{id:int}")]
        public ActionResult Delete(int id)
        {
            var product = _uof.ProductRepository.GetById(prod => prod.Id == id);
            if (product is null)
            {
                return NotFound();
            }

            _uof.ProductRepository.Delete(product);
            _uof.Commit();
            return Ok(product);
        }

    }
}