using EComm.API.BusinessDomain.DTOs.RequestsDTO;
using EComm.API.BusinessDomain.DTOs.ResponsesDTOs;
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
        public Task<int> AddProductAsync(ProductRequestDTO productDTO);
        public Task<ProductResponseDTO> EditProductAsync(ProductRequestDTO productDTO, Guid id);
        public Task DeleteProductAsync(Guid id);
        public Task<ProductResponseDTO?> GetProductByIdAsync(Guid id);
        public Task<IEnumerable<ProductResponseDTO?>> ListAllProductsAsync(Guid customerId);
      //  public Task<bool> AdminCheckAsync(bool isAdmin);

    }
}
