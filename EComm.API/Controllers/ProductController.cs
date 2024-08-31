using EComm.API.BusinessDomain.DTOs;
using EComm.API.BusinessDomain.Implementation.Services;
using EComm.API.BusinessDomain.Interfaces.IServices;
using EComm.API.Infrastructure.Entities;
using EComm.API.View_Models;
using EComm.API.Views;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Mapster;


namespace EComm.API.Controllers
{
    [Route("api/Product")]
    [ApiController]
    public class ProductController(IProductService productService) : ControllerBase
    {
        [HttpPost("AddProduct")]
        public async Task<ActionResult> PostProduct([FromBody] ProductVM productVM)
        {
            if (ModelState.IsValid)
            {
                var productDTO = productVM.Adapt<ProductDTO>();
                await productService.AddProductAsync(productDTO);
                return Ok("Product Added Successfully");
            }
            return BadRequest("InValidData");
        }
        [HttpGet("GetProductById{id}")]
        public async Task<ActionResult<Product>> GetProductById(Guid id)
        {
            var product = await productService.GetProductByIdAsync(id);
            if (product == null)
                return NotFound("Product doesn`t exist");
            return Ok($"{product} Product Retrieved Successfully");
        }
        [HttpGet("GetAllProducts")]
        public async Task<ActionResult<Product>> GetAllProducts()
        {
            if (ModelState.IsValid)
            {
                var AllProducts = await productService.ListAllProductsAsync();
                if (AllProducts == null)
                    return NotFound("No Products Founded");
                return Ok($"{AllProducts} Products Retrieved Successfully");
            }
            return BadRequest("Invalid Data");
        }
        [HttpDelete("DeleteProduct{id}")]
        public async Task<ActionResult> DeleteProduct(Guid id)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await productService.DeleteProductAsync(id);
                    return Ok("Product Deleted Successfully");

                }
                catch (Exception ex)
                { 
                    return BadRequest(ex.Message);
                }
            }

            return BadRequest("InValid Data");
        }

       [HttpPut("UpdateProduct{id}")]
       public async Task<ActionResult<Product>> PutProduct([FromBody] ProductVM productVM , Guid id)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var productDTO = productVM.Adapt<ProductDTO>();
                    await productService.EditProductAsync(productDTO, id);
                    return Ok("Product Updated Successfully");
                }
                catch (Exception ex)
                { 
                    return BadRequest(ex.Message);
                }
            }
            return BadRequest("Invalid Data");
        }
    }
}
