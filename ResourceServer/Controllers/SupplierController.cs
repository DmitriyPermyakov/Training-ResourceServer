using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ResourceServer.DTO.Requests;
using ResourceServer.DTO.Responses;
using ResourceServer.Models;
using ResourceServer.Repositories;

namespace ResourceServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SupplierController : ControllerBase
    {
        private readonly ISupplierRepo repo;
        public SupplierController(ISupplierRepo repo) 
        {
            this.repo = repo;
        }

        [HttpGet("getById/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var supplier = await repo.GetByIdAsync(id);
                return Ok(supplier);
            }
            catch(InvalidOperationException)
            {
                return NotFound("There is no supplier with this id");
            }
        }

        [HttpGet("getAll")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var suppliers = await repo.GetAllAsync();
                return Ok(suppliers);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateAsync([FromBody] CreateSupplierRequest supplierRequest)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(supplierRequest);

                SupplierResponse supplier = await repo.CreateAsync(supplierRequest);                
                return Ok(supplier);                
            }
            catch(ArgumentNullException ex)
            {
                return BadRequest(ex.Message);
            }
            catch(Exception ex)
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
                return Ok("Supplier was deleted");
            }            
            catch (InvalidOperationException ex) 
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut("update")]
        public async Task<IActionResult> UpdateAsync([FromBody] UpdateSupplierRequest supplierRequest)
        {
            try
            {
                if(!ModelState.IsValid)
                    return BadRequest(supplierRequest);

                await repo.UpdateAsync(supplierRequest);
                return Ok("Supplier updated");
            }
            catch(ArgumentNullException ex)
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
