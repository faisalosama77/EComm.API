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
    public class ProductService(IProductRepository productRepository, IUnitOfWork unitOfWork) : IProductService
    {
        public async Task AddProductAsync(ProductDTO productDTO)
        {
            var product = productDTO.Adapt<Product>();
            await productRepository.CreateProductAsync(product);
            await unitOfWork.SaveChangesAsync();
        }

        public async Task<bool> AdminCheckAsync(bool isAdmin)
        {
            if (isAdmin == true) 
            {
                await Task.CompletedTask;
                return true; 
            }
            await Task.CompletedTask;
            return false;

        }
        public async Task DeleteProductAsync(Guid id)
        {
            var deletedProduct = await productRepository.GetProductByIdAsync(id);
            if (deletedProduct == null)
                throw new ArgumentException("Invalid Product Id", nameof(id));
            var delProduct = deletedProduct.Adapt<Product>();
            delProduct.IsDeleted = true;
            await productRepository.DeleteProductAsync(delProduct);
            await unitOfWork.SaveChangesAsync();
        }

        public async Task EditProductAsync(ProductDTO productDTO, Guid id)
        {
            var productFromDb = await productRepository.GetProductByIdAsync(id);
            if (productFromDb == null)
                throw new ArgumentException("Invalid Order Id", nameof(id));
            productFromDb.Name = productDTO.Name;
            productFromDb.Description = productDTO.Description;
            productFromDb.Amount = productDTO.Amount;
            productFromDb.Type = productDTO.Type;
            if (productDTO.Quantity != productFromDb.Quantity)
            {
                productFromDb.Status = SetStatus(productDTO.Quantity);
                productFromDb.Quantity = productDTO.Quantity;
            }

            await productRepository.UpdateProductAsync(productFromDb);
            await unitOfWork.SaveChangesAsync();
          // if (await unitOfWork.SaveChangesAsync == 1) { }
        }

        public async Task<ProductDTO?> GetProductByIdAsync(Guid id)
        {
            var Product = await productRepository.GetProductByIdAsync(id);
            
            var wantedProduct = Product.Adapt<ProductDTO>();
            await unitOfWork.SaveChangesAsync();
            if (wantedProduct.IsDeleted == true)
                return null;
            return wantedProduct;
        }

        public async Task<IEnumerable<ProductDTO?>> ListAllProductsAsync()
        {
            // customr service 
            //if CS.Isadmis == true
            var Products = await productRepository.GetAllProductsAsync();
            await unitOfWork.SaveChangesAsync();
            if (Products is null)
                return null;
            var allProducts = Products.Adapt<List<ProductDTO>>();
            return allProducts.Where(a => a.IsDeleted == false);
        }

        private string SetStatus(int quantity)
        {
            return quantity switch
            {
                0 => "Out of stock",
                <= 5 => "Limited",
                _ => "Stocked",
            };
        }

    }
}
