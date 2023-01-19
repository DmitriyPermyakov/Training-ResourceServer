using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ResourceServer.DTO.Requests;
using ResourceServer.Models;
using ResourceServer.Repositories;

namespace ResourceServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepo repo;
        public ProductController(IProductRepo repo)
        {
            this.repo = repo;
        }
        [HttpPost("create")]
        public async Task<IActionResult> CreateAsync(CreateProductRequest productRequest)
        {
            try
            {
                if(!ModelState.IsValid)
                {
                    return BadRequest(productRequest);
                }
                
                Product product = await repo.CreateAsync(productRequest);
                return Ok(product);
            }
            catch(ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch(InvalidOperationException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("remove/{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            try
            {
                await repo.DeleteAsync(id);
                return Ok("Product was deleted successfully");
            }
            catch(InvalidOperationException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("getById/{id}")]
        public async Task<IActionResult> GetById (int id)
        {
            try
            {
                Product product = await repo.GetByIdAsync(id);
                return Ok(product);
            }
            catch(InvalidOperationException)
            {
                return NotFound("There is no product with this id");
            }
        }

        [HttpGet("getAll")]
        public async Task<IActionResult> GetAllAsync()
        {
            List<Product> products = await repo.GetAllAsync();
            return Ok(products);
        }

        [HttpPut("update")]
        public async Task<IActionResult> UpdateAsync(UpdateProductRequest product)
        {
            try
            {
                if(!ModelState.IsValid)
                {
                    return BadRequest(product);
                }

                await repo.UpdateAsync(product);
                return Ok("Product was successfully updated");
            }
            catch (ArgumentNullException ex)
            {
                return BadRequest(ex.Message);
            }
            catch(InvalidOperationException ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
