using EComm.API.BusinessDomain.DTOs;
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
        public async Task<int> AddProductAsync(ProductDTO productDTO)
        {
            var product = productDTO.Adapt<Product>();
            await productRepository.CreateProductAsync(product);
            var result = await unitOfWork.SaveChangesAsync();
            return result;
        }
        public async Task DeleteProductAsync(Guid id)
        {
            var deletedProduct = await productRepository.GetProductByIdAsync(id);
            if (deletedProduct == null)
                throw new ArgumentException("Invalid Product Id", nameof(id));
            deletedProduct.IsDeleted = true;
            await productRepository.DeleteProductAsync(deletedProduct);
            var result = await unitOfWork.SaveChangesAsync();
            if (result == 0)
                throw new ArgumentException("Can't Delete Product");
        }

        public async Task<ProductResponseDTO> EditProductAsync(ProductDTO productDTO, Guid id)
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

            await productRepository.UpdateProductAsync(productFromDb);
            var result = await unitOfWork.SaveChangesAsync();
            if (result == 0)
                throw new ArgumentException("Can't Update Customer");
            var productForResponse = productFromDb.Adapt<ProductResponseDTO>();
            return productForResponse;
            
        }

        public async Task<Product?> GetProductByIdAsync(Guid id)
        {
            var Product = await productRepository.GetProductByIdAsync(id);
           // var wantedProduct = Product.Adapt<ProductResponseDTO>();
            if (Product.IsDeleted == true)
                return null;
            return Product;
        }

        public async Task<IEnumerable<ProductResponseDTO?>> ListAllProductsAsync(Guid customerId)
        {
            var customer = await customerService.GetUserById(customerId);
            if (customer is null)
                return null;
            var Products = await productRepository.GetAllProductsAsync();
            var allProducts = Products.Adapt<List<ProductResponseDTO>>();
            if (customer.IsAdmin == false)
                return allProducts.Where(a => a.IsDeleted == false);
            return allProducts;
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
