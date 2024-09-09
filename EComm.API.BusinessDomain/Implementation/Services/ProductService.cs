using EComm.API.BusinessDomain.DTOs.RequestsDTO;
using EComm.API.BusinessDomain.DTOs.ResponsesDTOs;
using EComm.API.BusinessDomain.Interfaces.IServices;
using EComm.API.Infrastructure.DbContexts;
using EComm.API.Infrastructure.Entities;
using EComm.API.Infrastructure.Implementation.Repositories;
using EComm.API.Infrastructure.Interfaces.IRepositories;
using Mapster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EComm.API.BusinessDomain.Implementation.Services
{
    public class ProductService(IProductRepository productRepository, IUnitOfWork unitOfWork,ICustomerService customerService) : IProductService
    {
        public async Task<int> AddProductAsync(ProductRequestDTO productDTO)
        {
            var product = productDTO.Adapt<Product>();
            await productRepository.CreateProductAsync(product);
            var isSaved = await unitOfWork.SaveChangesAsync();
            return isSaved;
        }
        public async Task DeleteProductAsync(Guid id)
        {
            var deletedProduct = await productRepository.GetProductByIdAsync(id);
            if (deletedProduct == null)
                throw new ArgumentException("Invalid Product Id", nameof(id));
            deletedProduct.IsDeleted = true;
            await productRepository.UpdateProductAsync(deletedProduct , deletedProduct.Id);
            var result = await unitOfWork.SaveChangesAsync();
            if (result == 0)
                throw new ArgumentException("Can't Delete Product");
        }

        public async Task<ProductResponseDTO> EditProductAsync(ProductRequestDTO productDTO, Guid id)
        {
            var productFromDb = await productRepository.GetProductByIdAsync(id);
            if (productFromDb == null)
              throw new NullReferenceException("Invalid Order Id");

            productFromDb.Name = productDTO.Name;
            productFromDb.Description = productDTO.Description;
            productFromDb.Amount = productDTO.Amount;
            productFromDb.Type = productDTO.Type;
            productFromDb.Status = productDTO.Status;

            if (productDTO.Quantity != productFromDb.Quantity)
            {
                //productFromDb.Status = SetStatus(productDTO.Quantity);
                productFromDb.Quantity = productDTO.Quantity;
            }

            await productRepository.UpdateProductAsync(productFromDb , productFromDb.Id);
            var result = await unitOfWork.SaveChangesAsync();
            if (result == 0)
                throw new ArgumentException("Can't Update Customer");
            var productDataDTO = productFromDb.Adapt<ProductResponseDTO>();
            return productDataDTO;
            
        }

        public async Task<ProductResponseDTO?> GetProductByIdAsync(Guid id)
        {
            var Product = await productRepository.GetProductByIdAsync(id);
           var wantedProduct = Product.Adapt<ProductResponseDTO>();
            if (wantedProduct.IsDeleted == true)
                return null;
            return wantedProduct;
        }

        public async Task<IEnumerable<ProductResponseDTO?>> ListAllProductsAsync(Guid customerId)
        {
            var customer = await customerService.GetUserById(customerId);
            if (customer is null)
                return null;
            var Products = await productRepository.GetAllProductsAsync();
            var allProductsData = Products.Adapt<List<ProductResponseDTO>>();
            if (customer.IsAdmin == false)
                return allProductsData.Where(a => a.IsDeleted == false);
            return allProductsData;
        }

        //private string SetStatus(int quantity)
        //{
        //    return quantity switch
        //    {
        //        0 => "Out of stock",
        //        <= 5 => "Limited",
        //        _ => "Stocked",
        //    };
        //}

    }
}
