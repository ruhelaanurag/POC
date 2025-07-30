using IR.ApiTest.Contracts;
using IR.ApiTest.Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace IR.ApiTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _productRepository;
        public ProductController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        [HttpGet(Name = "GetAllProducts")]
        public async Task<ActionResult<List<Product>>> GetAll()
        {
            try
            {
                var result = await _productRepository.GetAllAsync();
                return Ok(result);
            }
            catch (Exception)
            {
                return StatusCode(500, "Error occured while processing your request");
            }
        }

        [HttpPost(Name = "AddProduct")]
        public async Task<ActionResult<int>> Add(Product product)
        {
            try
            {
                var result = await _productRepository.AddAsync(product);
                return CreatedAtAction(nameof(GetById), new{ id = result.Id}, result);
            }
            catch (Exception)
            {
                return BadRequest("Error occured while processing your request");
            }
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Product>> GetById(int id)
        {
            try
            {
                var result = await _productRepository.GetByIdAsync(id);
                if (result == null)
                    return NotFound();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Error occured while processing your request");
            }
        }

        [HttpPatch("{Id:int}")]
        public async Task<IActionResult> UpdateProduct([FromBody] JsonPatchDocument<Product> productPatch, int Id)
        {
            try
            {
                var existingProduct = await _productRepository.GetByIdAsync(Id);
                if (existingProduct == null)
                    return NotFound();
                productPatch.ApplyTo(existingProduct);
                var result = await _productRepository.UpdateAsync(existingProduct, Id);
                return Ok(result);
            }
            catch (Exception)
            {
                return StatusCode(500, "Error occured while processing your request");
            }
        }
    }
}
