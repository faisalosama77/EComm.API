using EComm.API.BusinessDomain.DTOs;
using EComm.API.Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EComm.API.BusinessDomain.Interfaces.IServices
{
    public interface IProductService
    {
        public Task<int> AddProductAsync(ProductDTO productDTO);
        public Task<ProductResponseDTO> EditProductAsync(ProductDTO productDTO, Guid id);
        public Task DeleteProductAsync(Guid id);
        public Task<Product?> GetProductByIdAsync(Guid id);
        public Task<IEnumerable<ProductResponseDTO?>> ListAllProductsAsync(Guid customerId);
      //  public Task<bool> AdminCheckAsync(bool isAdmin);

    }
}
