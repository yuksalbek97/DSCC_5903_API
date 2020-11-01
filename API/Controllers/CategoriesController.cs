using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using API.Models;
using API.Repositories;
using System.Transactions;
using Microsoft.AspNetCore.Cors;

namespace API.Controllers
{
    [Route("api/categories")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryRepository _categoryRepository;
        public CategoriesController(ICategoryRepository catRepository)
        {
            _categoryRepository = catRepository;
        }
        // GET: api/categories         
        [HttpGet]
        public IActionResult Get()
        {
            var categories = _categoryRepository.GetAll();
            return new OkObjectResult(categories);

        }

        // GET: api/categories/5         
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var product = _categoryRepository.GetById(id);
            return new OkObjectResult(product);
        }
        // POST: api/categories
        [HttpPost]
        public IActionResult Post([FromBody]Category category)
        {
            using (var scope = new TransactionScope())
            {
                _categoryRepository.Create(category);
                scope.Complete();
                return CreatedAtAction(nameof(Get), new { id = category.CategoryId }, category);
            }
        }
        // PUT: api/categories/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]Category category)
        {
            if (category != null)
            {
                using (var scope = new TransactionScope())
                {
                    _categoryRepository.Update(category);
                    scope.Complete();
                    return new OkResult();
                }
            }
            return new NoContentResult();
        }
        // DELETE: api/categories/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _categoryRepository.Delete(id);
            return new OkResult();
        }
    }
}
