using EComm.API.Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EComm.API.Infrastructure.Interfaces.IRepositories
{
    public interface IProductRepository
    {
        public Task CreateProductAsync(Product product);
        public Task UpdateProductAsync(Product product);
        public Task DeleteProductAsync(Product product);
        public Task<Product?> GetProductByIdAsync(Guid id);
        public Task<IEnumerable<Product?>> GetAllProductsAsync();
    }
}
