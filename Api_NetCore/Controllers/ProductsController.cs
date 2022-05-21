using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Api_NetCore.Data;
using Api_NetCore.Filters;
using Api_NetCore.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Api_NetCore.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly AppDbContext _dbContext;

        public ProductsController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        
        
        [HttpGet]
        [ServiceFilter(typeof(ApiLoggingFilter))]
        public ActionResult<IEnumerable<Product>> Get()
        {
            var products = _dbContext.Products.AsNoTracking().ToList();
            
            if(products is null)
            {
                return NotFound();
            }
            return products;
        }

        [HttpGet("{id:int}", Name = "GetThisProduct")]
        public ActionResult<Product> Get(int id)
        {
            var product = _dbContext.Products.FirstOrDefault(prod => prod.Id == id);
            
            if (product is null)
            {
                return NotFound();
            }
            return product;
        }

        [HttpPost]
        public ActionResult Post(Product product)
        {
            if (product is null)
            {
                return BadRequest();
            }
            
            _dbContext.Products.Add(product);
            _dbContext.SaveChanges();
            return new CreatedAtRouteResult("GetThisProduct", new {id = product.Id}, product);
        }

        [HttpPut("{id:int}")]
        public ActionResult Put(int id, Product product)
        {
            if (id != product.Id)
            {
                return BadRequest();
            }

            _dbContext.Entry(product).State = EntityState.Modified;
            _dbContext.SaveChanges();

            return Ok(product);
        }

        [HttpDelete("{id:int}")]
        public ActionResult Delete(int id)
        {
            var product = _dbContext.Products.FirstOrDefault(prod => prod.Id == id);
            if (product is null)
            {
                return NotFound();
            }

            _dbContext.Remove(product);
            _dbContext.SaveChanges();
            return Ok(product);
        }

    }
}