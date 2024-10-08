﻿using EComm.API.BusinessDomain.Implementation.Services;
using EComm.API.BusinessDomain.Interfaces.IServices;
using EComm.API.Infrastructure.Entities;
using EComm.API.View_Models;
using EComm.API.Views;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Mapster;
using EComm.API.RunTime.Classes;
using System;
using Microsoft.AspNetCore.Authorization;
using EComm.API.BusinessDomain.DTOs.RequestsDTO;


namespace EComm.API.Controllers
{
    [Route("api/Product")]
    [ApiController]
    public class ProductController(IProductService productService) : ControllerBase
    {
        //[Authorize]
        [HttpPost]
        public async Task<BaseResponse> Post([FromBody] ProductRequestVM productRequestVM)
        {
            if (ModelState.IsValid)
            {
                    var productDTO = productRequestVM.Adapt<ProductRequestDTO>();
                    var isSaved = await productService.AddProductAsync(productDTO);
                    if(isSaved == 0 )
                        return new ErrorResponse() { StatusCode = 400, Message = "Bad Request", Error = "Can't Add Product"};
                    return new BaseResponse() { StatusCode = 200, Message = "Product Added Succeessfully" };
            }
            return new ErrorResponse() { StatusCode = 400, Message = "BadRequest", Error = "Invalid Data" };
        }

        //[Authorize(Roles = "Admin")]
        [HttpGet("{id}")]
        public async Task<BaseResponse> GetProductById([FromRoute]Guid id)
        {
            if (ModelState.IsValid)
            {
                var product = await productService.GetProductByIdAsync(id);
                if (product == null)
                    return new ErrorResponse() { StatusCode = 404, Message = "Not Found", Error = "Product Doesn't Exist " };
                var productVM = product.Adapt<ProductResponseVM>();
                return new SuccessResponse<ProductResponseVM>() { StatusCode = 200, Message = "Product Retrieved Successfully", Data = productVM };
            }
            return new ErrorResponse() { StatusCode = 400, Message = "BadRequest", Error = "Invalid Data" };
        }
        [HttpGet("{id}")]
        public async Task<BaseResponse> Get(Guid customerId)
        {
            if (ModelState.IsValid)
            {
                    var AllProductsDto = await productService.ListAllProductsAsync(customerId);
                    if (AllProductsDto == null)
                        return new ErrorResponse() { StatusCode = 404, Message = "Not Found", Error = "Customer Id Doesn't Exist" };
                    var allProductsVM = AllProductsDto.Adapt<List<ProductResponseVM>>();
                    return new SuccessResponse<List<ProductResponseVM>>() { StatusCode = 200, Message = "Products Retrieved Successfully", Data = allProductsVM };  
            }
            return new ErrorResponse() { StatusCode = 400, Message = "BadRequest", Error = "Invalid Data" };
        }
        [HttpDelete("{id}")]
        public async Task<BaseResponse> Delete(Guid id)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await productService.DeleteProductAsync(id);
                    return new BaseResponse() { StatusCode = 200, Message = "Product Deleted Succeessfully" };

                }
                catch (ArgumentException argumentException)
                {
                    return new ErrorResponse() { StatusCode = 400, Message = "Bad Request", Error = argumentException.Message };
                }
            }

            return new ErrorResponse() { StatusCode = 400, Message = "BadRequest", Error = "Invalid Data" };
        }

        [HttpPut("{id}")]
       public async Task<BaseResponse> Put([FromBody] ProductRequestVM productRequestVM , Guid id)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var productDTO = productRequestVM.Adapt<ProductRequestDTO>();
                    var productdb = await productService.EditProductAsync(productDTO, id);
                    var productResponse = productdb.Adapt<ProductResponseVM>();
                    return new SuccessResponse<ProductResponseVM>() { StatusCode = 200, Message = "Product Updated Successfully", Data = productResponse };   //token
                }
                catch (NullReferenceException nullReferenceException)
                {
                    return new ErrorResponse() { StatusCode = 400, Message = "Bad Request", Error = nullReferenceException.Message };
                }
                catch (ArgumentException argumentException)
                {
                    return new ErrorResponse() { StatusCode = 400, Message = "Bad Request", Error = argumentException.Message };
                }
            }
            return new ErrorResponse() { StatusCode = 400, Message = "BadRequest", Error = "Invalid Data" };
        }
    }
}
