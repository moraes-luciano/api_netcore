using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Api_NetCore.Data;
using Api_NetCore.Models;
using Api_NetCore.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Api_NetCore.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CategoriesController : ControllerBase
    {
        private readonly IUnitOfWork _uof;

        public CategoriesController(IUnitOfWork dbContext)
        {
            _uof = dbContext;
        }
        
        
        [HttpGet]
        public ActionResult<IEnumerable<Category>> Get()
        {
            var categories = _uof.CategoryRepository.Get().ToList();
            return categories;
        }


        [HttpGet("{id:int}", Name = "GetThisCategory")]
        public ActionResult<Category> Get(int id)
        {
            var category = _uof.CategoryRepository.GetById(catg => catg.Id == id);
            if (category is null)
            {
                return NotFound();
            }

            return Ok(category);
        }

        [HttpGet("products")]
        public ActionResult<IEnumerable<Category>> GetCategoryWithProduct()
        {
            return _uof.CategoryRepository.GetCategoryByProducts().ToList();
        }

        [HttpPost]
        public ActionResult<Category> Post(Category category)
        {
            if (category is null)
            {
                return BadRequest();
            }

            _uof.CategoryRepository.Add(category);
            _uof.Commit();

            return new CreatedAtRouteResult("GetThisCategory", new {id = category.Id}, category);
        }

        [HttpPut("{id:int}")]
        public ActionResult<Category> Put(int id, Category category)
        {
            if (id != category.Id)
            {
                return BadRequest();
            }

            _uof.CategoryRepository.Update(category);
            _uof.Commit();

            return Ok(category);
        }

        [HttpDelete("{id:int}")]
        public ActionResult<Category> Delete(int id)
        {
            var category = _uof.CategoryRepository.GetById(catg => catg.Id == id);
            if (category is null)
            {
                return BadRequest();
            }

            _uof.CategoryRepository.Delete(category);
            _uof.Commit();

            return Ok(category);
        }
    }
}