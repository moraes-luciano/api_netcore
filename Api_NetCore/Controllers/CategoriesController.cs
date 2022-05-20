using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Api_NetCore.Data;
using Api_NetCore.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Api_NetCore.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CategoriesController : ControllerBase
    {
        private readonly AppDbContext _dbContext;

        public CategoriesController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        
        
        [HttpGet]
        public ActionResult<IEnumerable<Category>> Get()
        {
            var categories = _dbContext.Categories.AsNoTracking().ToList();
            return categories;
        }


        [HttpGet("{id:int}", Name = "GetThisCategory")]
        public ActionResult<Category> Get(int id)
        {
            var category = _dbContext.Categories.FirstOrDefault(catg => catg.Id == id);
            if (category is null)
            {
                return NotFound();
            }

            return Ok(category);
        }

        [HttpGet("products")]
        public ActionResult<IEnumerable<Category>> GetCategoryWithProduct()
        {
            return _dbContext.Categories.Include(p => p.Products).ToList();
        }

        [HttpPost]
        public ActionResult<Category> Post(Category category)
        {
            if (category is null)
            {
                return BadRequest();
            }

            _dbContext.Categories.Add(category);
            _dbContext.SaveChanges();

            return new CreatedAtRouteResult("GetThisCategory", new {id = category.Id}, category);
        }

        [HttpPut("{id:int}")]
        public ActionResult<Category> Put(int id, Category category)
        {
            if (id != category.Id)
            {
                return BadRequest();
            }

            _dbContext.Entry(category).State = EntityState.Modified;
            _dbContext.SaveChanges();

            return Ok(category);
        }

        [HttpDelete("{id:int}")]
        public ActionResult<Category> Delete(int id)
        {
            var category = _dbContext.Categories.FirstOrDefault(catg => catg.Id == id);
            if (category is null)
            {
                return BadRequest();
            }

            _dbContext.Categories.Remove(category);
            _dbContext.SaveChanges();

            return Ok(category);
        }
    }
}