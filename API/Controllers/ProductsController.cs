using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Transactions;
using API.Models;
using API.Repositories;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Produces("application/json")]
    [Route("api/products")]
    public class ProductsController : Controller
    {
        private readonly IProductRepository _productRepository; 
        public ProductsController(IProductRepository productRepository) 
        { 
            _productRepository = productRepository; 
        }
        // GET: api/products         
        [HttpGet]
        public IActionResult Get()         
        {             
            var products = _productRepository.GetAll();
            return new OkObjectResult(products);
            
        }

        // GET: api/products/5         
        [HttpGet("{id}")]         
        public IActionResult Get(int id)         
        {             
            var product = _productRepository.GetById(id);
            return new OkObjectResult(product);           
        }
        // POST: api/products
        [HttpPost]
        public IActionResult Post([FromBody]Product product)
        { 
            using (var scope = new TransactionScope())
            { 
                _productRepository.Create(product); 
                scope.Complete();   
                return CreatedAtAction(nameof(Get), new { id = product.ProductId }, product);            
            }         
        }
        // PUT: api/products/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]Product product)
        {
            if (product != null)
            {
                using (var scope = new TransactionScope())
                {
                    _productRepository.Update(product);
                    scope.Complete();
                    return new OkResult();
                }
            }
            return new NoContentResult();
        }
        // DELETE: api/products/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _productRepository.Delete(id);
            return new OkResult();
        } 
    }
}
